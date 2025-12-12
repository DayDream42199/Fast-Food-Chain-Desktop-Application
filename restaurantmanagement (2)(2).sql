-- phpMyAdmin SQL Dump
-- version 5.1.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Nov 17, 2025 at 04:36 PM
-- Server version: 5.7.24
-- PHP Version: 8.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `restaurantmanagement`
--
DROP DATABASE IF EXISTS `restaurantmanagement`;
CREATE DATABASE IF NOT EXISTS `restaurantmanagement` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `restaurantmanagement`;

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`superadmin`@`localhost` PROCEDURE `check_inventory_item` (IN `p_menu_id` INT, IN `p_quantity` INT, OUT `p_is_sufficient` BOOLEAN)   BEGIN
    DECLARE total_quantity INT DEFAULT 0;

    SELECT IFNULL(SUM(Quantity), 0)
    INTO total_quantity
    FROM inventory_item
    WHERE Menu_ID = p_menu_id
      AND Expiry_date >= CURDATE();

    IF total_quantity < p_quantity THEN
        SET p_is_sufficient = FALSE;
    ELSE
        SET p_is_sufficient = TRUE;
    END IF;
END$$

CREATE DEFINER=`superadmin`@`localhost` PROCEDURE `deduct_inventory_item` (IN `p_menu_id` INT, IN `p_quantity` INT)   begin
    declare total_quantity int default 0;
    declare itemleft int default p_quantity;
    declare done int default false;
    declare current_batch_id int;
    declare current_batch_quantity int;
    declare batch_cursor cursor for 
        select Inventory_Item_ID, Quantity from inventory_item 
        where Menu_ID = p_menu_id and Expiry_date >= curdate()
        order by Expiry_date asc, Inventory_Item_ID asc;
    declare continue handler for not found set done = true;

    start transaction;
    select IFNULL(sum(Quantity), 0) into total_quantity
    from inventory_item 
    where Menu_ID = p_menu_id and Expiry_date >= curdate();
    if total_quantity < p_quantity then
        rollback;
        signal sqlstate '45000' set message_text = 'Insufficient inventory quantity';
    else
        open batch_cursor;
        read_loop: loop
            fetch batch_cursor into current_batch_id, current_batch_quantity;
            if done then
                leave read_loop;
            end if;

            if current_batch_quantity >= itemleft then
                update inventory_item 
                set Quantity = Quantity - itemleft 
                where Inventory_Item_ID = current_batch_id;
                set itemleft = 0;
            else
                update inventory_item 
                set Quantity = 0 
                where Inventory_Item_ID = current_batch_id;
                set itemleft = itemleft - current_batch_quantity;
            end if;

            if itemleft = 0 then
                leave read_loop;
            end if;
        end loop;
        close batch_cursor;
        commit;
    end if;
end$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `cashier`
--

CREATE TABLE `cashier` (
  `Cs_Em_ID` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `cashier`
--

INSERT INTO `cashier` (`Cs_Em_ID`) VALUES
(1),
(2);

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `Category_ID` int(10) UNSIGNED NOT NULL,
  `Name` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`Category_ID`, `Name`) VALUES
(1, 'Food'),
(2, 'Drinks'),
(3, 'Others');

-- --------------------------------------------------------

--
-- Table structure for table `chef`
--

CREATE TABLE `chef` (
  `Cf_Em_ID` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `chef`
--

INSERT INTO `chef` (`Cf_Em_ID`) VALUES
(3);

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `Em_ID` int(10) UNSIGNED NOT NULL,
  `FName` varchar(30) NOT NULL,
  `LName` varchar(30) NOT NULL,
  `Email` varchar(40) NOT NULL,
  `Phone` varchar(12) NOT NULL,
  `DOB` date NOT NULL,
  `StartDate` date NOT NULL,
  `Salary` decimal(12,2) NOT NULL,
  `Status` enum('active','inactive') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`Em_ID`, `FName`, `LName`, `Email`, `Phone`, `DOB`, `StartDate`, `Salary`, `Status`) VALUES
(0, 'super', 'admin', '-', '0', '1999-11-19', '1999-11-19', '0.00', 'active'),
(1, 'John', 'Doe', 'JohnDoe@gmail.com', '0812345678', '2025-11-17', '2025-11-17', '12345.00', 'active'),
(2, 'Jane', 'Doe', 'JaneDoe@gmail.com', '0912345678', '2025-11-17', '2025-11-17', '12345.00', 'inactive'),
(3, 'Sam', 'Drake', 'SamDrake@gmail.com', '0712345678', '2025-11-17', '2025-11-17', '54321.00', 'active'),
(4, 'Gru', 'Simons', 'GruSimons@hotmail.com', '9876543210', '2025-11-17', '2025-11-17', '54263.00', 'active'),
(5, 'Peak', 'Nicholas', 'PeakNicholas@outlook.com', '5478963210', '2025-11-17', '2025-11-17', '54896.00', 'active');

--
-- Triggers `employee`
--
DELIMITER $$
CREATE TRIGGER `employee_log_delete` AFTER DELETE ON `employee` FOR EACH ROW BEGIN
    UPDATE tableLastUpdate SET lastUpdatedTime = NOW() WHERE tableName = 'employee';
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `employee_log_insert` AFTER INSERT ON `employee` FOR EACH ROW BEGIN
    UPDATE tableLastUpdate SET lastUpdatedTime = NOW() WHERE tableName = 'employee';
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `employee_log_update` AFTER UPDATE ON `employee` FOR EACH ROW BEGIN
    UPDATE tableLastUpdate SET lastUpdatedTime = NOW() WHERE tableName = 'employee';
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `prevent_superadmin_delete` BEFORE DELETE ON `employee` FOR EACH ROW BEGIN
    IF OLD.Em_ID = 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Super admin cannot be modified.';
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `prevent_superadmin_update` BEFORE UPDATE ON `employee` FOR EACH ROW BEGIN
    IF OLD.Em_ID = 0 THEN
        IF (NOT (NEW.Status <=> OLD.Status))
           AND (NEW.FName     <=> OLD.FName)
           AND (NEW.LName     <=> OLD.LName)
           AND (NEW.Email     <=> OLD.Email)
           AND (NEW.Phone     <=> OLD.Phone)
           AND (NEW.DOB       <=> OLD.DOB)
           AND (NEW.StartDate <=> OLD.StartDate)
           AND (NEW.Salary    <=> OLD.Salary)
        THEN
            SET @dummy = 0;
        ELSE
            SIGNAL SQLSTATE '45000' 
                SET MESSAGE_TEXT = 'Super admin can only have Status updated.';
        END IF;
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `employee_logindata`
--

CREATE TABLE `employee_logindata` (
  `Em_ID` int(10) UNSIGNED NOT NULL,
  `Login_ID` int(10) UNSIGNED NOT NULL,
  `Username` varchar(30) NOT NULL,
  `Password` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `employee_logindata`
--

INSERT INTO `employee_logindata` (`Em_ID`, `Login_ID`, `Username`, `Password`) VALUES
(0, 0, 'root', '$2a$12$afoh.hDNZOvf7IvyP2UoOeVjzxlQlGbkql.RJLV.31dSPdLy0q9jy'),
(1, 1, 'cashier1', '$2a$11$H/XZ765dQuzBVRv/FDjFiOsVkRnJ3I9vli/0.fGr2h1pwSP/nkLn6'),
(2, 2, 'cashier2', '$2a$11$WjGKzHqPaL58YXHjwJjJLe/T04vFGx540KFxzHPY0iY1Gg3oedi8y'),
(3, 3, 'chef', '$2a$11$ejWuRXHG/hLTcrsYnFZw3uPi8lFFHV2HQoOBqStIDX22N/6XuKux.'),
(4, 4, 'manager', '$2a$11$nDbeCFSD16sQu2ijUlQuV.8ofP0f4INxPDPRCiLyUVZUWCMA4J8Hm'),
(5, 5, 'superadmin', '$2a$11$aDD7YaLc/GivWxq5C3AFTe5586iDtJi5p5QljOgxUSyJAZtbcqY.2');

--
-- Triggers `employee_logindata`
--
DELIMITER $$
CREATE TRIGGER `employeeLogindata_log_delete` AFTER DELETE ON `employee_logindata` FOR EACH ROW BEGIN
    UPDATE tableLastUpdate SET lastUpdatedTime = NOW() WHERE tableName = 'employee_logindata';
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `employeeLogindata_log_insert` AFTER INSERT ON `employee_logindata` FOR EACH ROW BEGIN
    UPDATE tableLastUpdate SET lastUpdatedTime = NOW() WHERE tableName = 'employee_logindata';
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `employeeLogindata_log_update` AFTER UPDATE ON `employee_logindata` FOR EACH ROW BEGIN
    UPDATE tableLastUpdate SET lastUpdatedTime = NOW() WHERE tableName = 'employee_logindata';
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `prevent_superadmin_login_delete` BEFORE DELETE ON `employee_logindata` FOR EACH ROW BEGIN
    IF OLD.Em_ID = 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Super admin cannot be modified.';
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `prevent_superadmin_login_update` BEFORE UPDATE ON `employee_logindata` FOR EACH ROW BEGIN
    IF OLD.Em_ID = 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Super admin cannot be modified.';
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `inventory_item`
--

CREATE TABLE `inventory_item` (
  `Inventory_Item_ID` bigint(20) UNSIGNED NOT NULL,
  `Quantity` int(10) UNSIGNED NOT NULL,
  `Batch_Number` varchar(20) NOT NULL,
  `Expiry_date` date NOT NULL,
  `Shelf_location` varchar(50) NOT NULL,
  `Menu_ID` int(10) UNSIGNED DEFAULT NULL,
  `M_Em_ID` int(10) UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `inventory_item`
--

INSERT INTO `inventory_item` (`Inventory_Item_ID`, `Quantity`, `Batch_Number`, `Expiry_date`, `Shelf_location`, `Menu_ID`, `M_Em_ID`) VALUES
(1, 100, 'A12345', '2025-11-19', 'A1', 1, NULL),
(2, 50, 'A12346', '2026-02-01', 'A2', 2, NULL),
(3, 99, 'A00001', '2025-08-05', 'A0', 3, NULL),
(4, 3, 'B12345', '2026-03-01', 'A9', 4, NULL),
(5, 123, 'EF123456', '2029-01-16', 'A3', 4, NULL),
(6, 999, 'ERT123', '2025-03-11', 'ERER', 5, NULL);

--
-- Triggers `inventory_item`
--
DELIMITER $$
CREATE TRIGGER `inventoryitem_log_delete` AFTER DELETE ON `inventory_item` FOR EACH ROW BEGIN
    UPDATE tableLastUpdate SET lastUpdatedTime = NOW() WHERE tableName = 'inventory_item';
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `inventoryitem_log_insert` AFTER INSERT ON `inventory_item` FOR EACH ROW BEGIN
    UPDATE tableLastUpdate SET lastUpdatedTime = NOW() WHERE tableName = 'inventory_item';
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `inventoryitem_log_update` AFTER UPDATE ON `inventory_item` FOR EACH ROW BEGIN
    UPDATE tableLastUpdate SET lastUpdatedTime = NOW() WHERE tableName = 'inventory_item';
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `manager`
--

CREATE TABLE `manager` (
  `M_Em_ID` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `manager`
--

INSERT INTO `manager` (`M_Em_ID`) VALUES
(4);

-- --------------------------------------------------------

--
-- Table structure for table `menu_item`
--

CREATE TABLE `menu_item` (
  `Menu_ID` int(10) UNSIGNED NOT NULL,
  `Name` varchar(30) NOT NULL,
  `Price` decimal(12,2) NOT NULL,
  `Path` varchar(255) DEFAULT NULL,
  `Category_ID` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `menu_item`
--

INSERT INTO `menu_item` (`Menu_ID`, `Name`, `Price`, `Path`, `Category_ID`) VALUES
(1, 'Burger', '1.00', 'Resources/burger.jpg', 1),
(2, 'Fries', '0.50', 'Resources/fries.jpg', 1),
(3, 'Onion rings', '0.75', 'Resources/onionrings.jpg', 1),
(4, 'Soda', '0.75', 'Resources/soda.jpg', 2),
(5, 'Water', '1.00', 'Resources/water.jpg', 2);

--
-- Triggers `menu_item`
--
DELIMITER $$
CREATE TRIGGER `menuitem_log_delete` AFTER DELETE ON `menu_item` FOR EACH ROW BEGIN
    UPDATE tableLastUpdate SET lastUpdatedTime = NOW() WHERE tableName = 'menu_item';
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `menuitem_log_insert` AFTER INSERT ON `menu_item` FOR EACH ROW BEGIN
    UPDATE tableLastUpdate SET lastUpdatedTime = NOW() WHERE tableName = 'menu_item';
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `menuitem_log_update` AFTER UPDATE ON `menu_item` FOR EACH ROW BEGIN
    UPDATE tableLastUpdate SET lastUpdatedTime = NOW() WHERE tableName = 'menu_item';
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `order`
--

CREATE TABLE `order` (
  `Order_ID` bigint(20) UNSIGNED NOT NULL,
  `Timestamp` datetime NOT NULL,
  `Status` enum('received','preparing','ready','completed') NOT NULL,
  `Cs_Em_ID` int(10) UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Triggers `order`
--
DELIMITER $$
CREATE TRIGGER `order_log_delete` AFTER DELETE ON `order` FOR EACH ROW BEGIN
    UPDATE tableLastUpdate SET lastUpdatedTime = NOW() WHERE tableName = 'order';
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `order_log_insert` AFTER INSERT ON `order` FOR EACH ROW BEGIN
    UPDATE tableLastUpdate SET lastUpdatedTime = NOW() WHERE tableName = 'order';
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `order_log_update` AFTER UPDATE ON `order` FOR EACH ROW BEGIN
    UPDATE tableLastUpdate SET lastUpdatedTime = NOW() WHERE tableName = 'order';
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `orderdataprotection_delete` BEFORE DELETE ON `order` FOR EACH ROW BEGIN
	SIGNAL SQLSTATE '45000'
    	SET MESSAGE_TEXT = 'Updates are not allowed on this table';
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `orderdataprotection_update` BEFORE UPDATE ON `order` FOR EACH ROW BEGIN
    IF (NOT (NEW.Status <=> OLD.Status))
       AND (NEW.Order_ID  <=> OLD.Order_ID)
       AND (NEW.Timestamp <=> OLD.Timestamp)
       AND (NEW.Cs_Em_ID  <=> OLD.Cs_Em_ID)
    THEN
        SET @dummy = 0;
    ELSE
        SIGNAL SQLSTATE '45000'
            SET MESSAGE_TEXT = 'Only Status update is allowed on this table.';
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `order_item`
--

CREATE TABLE `order_item` (
  `Order_ID` bigint(20) UNSIGNED NOT NULL,
  `Order_Item_ID` int(10) UNSIGNED NOT NULL,
  `Quantity` int(10) UNSIGNED NOT NULL,
  `Menu_ID` int(10) UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Triggers `order_item`
--
DELIMITER $$
CREATE TRIGGER `orderItem_log_delete` AFTER DELETE ON `order_item` FOR EACH ROW BEGIN
    UPDATE tableLastUpdate SET lastUpdatedTime = NOW() WHERE tableName = 'order_item';
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `orderItem_log_insert` AFTER INSERT ON `order_item` FOR EACH ROW BEGIN
    UPDATE tableLastUpdate SET lastUpdatedTime = NOW() WHERE tableName = 'order_item';
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `orderItem_log_update` AFTER UPDATE ON `order_item` FOR EACH ROW BEGIN
    UPDATE tableLastUpdate SET lastUpdatedTime = NOW() WHERE tableName = 'order_item';
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `payment`
--

CREATE TABLE `payment` (
  `Payment_ID` bigint(20) UNSIGNED NOT NULL,
  `Timestamp` datetime NOT NULL,
  `Payment_Type` enum('cash','card') NOT NULL,
  `Total` decimal(12,2) NOT NULL,
  `Order_ID` bigint(20) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Triggers `payment`
--
DELIMITER $$
CREATE TRIGGER `payment_log_delete` AFTER DELETE ON `payment` FOR EACH ROW BEGIN
    UPDATE tableLastUpdate SET lastUpdatedTime = NOW() WHERE tableName = 'payment';
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `payment_log_insert` AFTER INSERT ON `payment` FOR EACH ROW BEGIN
    UPDATE tableLastUpdate SET lastUpdatedTime = NOW() WHERE tableName = 'payment';
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `payment_log_update` AFTER UPDATE ON `payment` FOR EACH ROW BEGIN
    UPDATE tableLastUpdate SET lastUpdatedTime = NOW() WHERE tableName = 'payment';
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `paymentdataprotection_delete` BEFORE DELETE ON `payment` FOR EACH ROW BEGIN
	SIGNAL SQLSTATE '45000'
    	SET MESSAGE_TEXT = 'Updates are not allowed on this table';
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `paymentdataprotection_update` BEFORE UPDATE ON `payment` FOR EACH ROW BEGIN
	SIGNAL SQLSTATE '45000'
    	SET MESSAGE_TEXT = 'Updates are not allowed on this table';
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `superadmin`
--

CREATE TABLE `superadmin` (
  `S_Em_ID` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `superadmin`
--

INSERT INTO `superadmin` (`S_Em_ID`) VALUES
(5);

-- --------------------------------------------------------

--
-- Table structure for table `tablelastupdate`
--

CREATE TABLE `tablelastupdate` (
  `tableName` varchar(30) NOT NULL,
  `lastUpdatedTime` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `tablelastupdate`
--

INSERT INTO `tablelastupdate` (`tableName`, `lastUpdatedTime`) VALUES
('employee', '2025-11-17 23:30:10'),
('employee_logindata', '2025-11-17 23:30:57'),
('inventory_item', '2025-11-17 23:33:56'),
('menu_item', '2025-11-17 23:26:38'),
('order', '2025-11-17 23:26:38'),
('order_item', '2025-11-17 23:26:38'),
('payment', '2025-11-17 23:26:38');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `cashier`
--
ALTER TABLE `cashier`
  ADD PRIMARY KEY (`Cs_Em_ID`);

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`Category_ID`);

--
-- Indexes for table `chef`
--
ALTER TABLE `chef`
  ADD PRIMARY KEY (`Cf_Em_ID`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`Em_ID`);

--
-- Indexes for table `employee_logindata`
--
ALTER TABLE `employee_logindata`
  ADD PRIMARY KEY (`Em_ID`,`Login_ID`),
  ADD UNIQUE KEY `Username` (`Username`);

--
-- Indexes for table `inventory_item`
--
ALTER TABLE `inventory_item`
  ADD PRIMARY KEY (`Inventory_Item_ID`),
  ADD KEY `FK_Menu_ID_Inventory_Item_Menu_Item` (`Menu_ID`),
  ADD KEY `FK_Em_ID_Inventory_Item_Manager` (`M_Em_ID`);

--
-- Indexes for table `manager`
--
ALTER TABLE `manager`
  ADD PRIMARY KEY (`M_Em_ID`);

--
-- Indexes for table `menu_item`
--
ALTER TABLE `menu_item`
  ADD PRIMARY KEY (`Menu_ID`),
  ADD KEY `FK_Category_ID_Menu_Item_Category` (`Category_ID`);

--
-- Indexes for table `order`
--
ALTER TABLE `order`
  ADD PRIMARY KEY (`Order_ID`),
  ADD KEY `FK_Em_ID_Order_Cashier` (`Cs_Em_ID`);

--
-- Indexes for table `order_item`
--
ALTER TABLE `order_item`
  ADD PRIMARY KEY (`Order_ID`,`Order_Item_ID`),
  ADD KEY `FK_Menu_ID_Order_Item_Menu_Item` (`Menu_ID`);

--
-- Indexes for table `payment`
--
ALTER TABLE `payment`
  ADD PRIMARY KEY (`Payment_ID`),
  ADD KEY `FK_Order_ID_Payment_Order` (`Order_ID`);

--
-- Indexes for table `superadmin`
--
ALTER TABLE `superadmin`
  ADD PRIMARY KEY (`S_Em_ID`);

--
-- Indexes for table `tablelastupdate`
--
ALTER TABLE `tablelastupdate`
  ADD PRIMARY KEY (`tableName`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `category`
--
ALTER TABLE `category`
  MODIFY `Category_ID` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `employee`
--
ALTER TABLE `employee`
  MODIFY `Em_ID` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `inventory_item`
--
ALTER TABLE `inventory_item`
  MODIFY `Inventory_Item_ID` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `menu_item`
--
ALTER TABLE `menu_item`
  MODIFY `Menu_ID` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `order`
--
ALTER TABLE `order`
  MODIFY `Order_ID` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `payment`
--
ALTER TABLE `payment`
  MODIFY `Payment_ID` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `cashier`
--
ALTER TABLE `cashier`
  ADD CONSTRAINT `FK_Em_ID_Cashier_employee` FOREIGN KEY (`Cs_Em_ID`) REFERENCES `employee` (`Em_ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `chef`
--
ALTER TABLE `chef`
  ADD CONSTRAINT `FK_Em_ID_Chef_employee` FOREIGN KEY (`Cf_Em_ID`) REFERENCES `employee` (`Em_ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `employee_logindata`
--
ALTER TABLE `employee_logindata`
  ADD CONSTRAINT `FK_Em_ID_Employee_logindata_employee` FOREIGN KEY (`Em_ID`) REFERENCES `employee` (`Em_ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `inventory_item`
--
ALTER TABLE `inventory_item`
  ADD CONSTRAINT `FK_Em_ID_Inventory_Item_Manager` FOREIGN KEY (`M_Em_ID`) REFERENCES `manager` (`M_Em_ID`) ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_Menu_ID_Inventory_Item_Menu_Item` FOREIGN KEY (`Menu_ID`) REFERENCES `menu_item` (`Menu_ID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `manager`
--
ALTER TABLE `manager`
  ADD CONSTRAINT `FK_Em_ID_Manager_employee` FOREIGN KEY (`M_Em_ID`) REFERENCES `employee` (`Em_ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `menu_item`
--
ALTER TABLE `menu_item`
  ADD CONSTRAINT `FK_Category_ID_Menu_Item_Category` FOREIGN KEY (`Category_ID`) REFERENCES `category` (`Category_ID`) ON UPDATE CASCADE;

--
-- Constraints for table `order`
--
ALTER TABLE `order`
  ADD CONSTRAINT `FK_Em_ID_Order_Cashier` FOREIGN KEY (`Cs_Em_ID`) REFERENCES `cashier` (`Cs_Em_ID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `order_item`
--
ALTER TABLE `order_item`
  ADD CONSTRAINT `FK_Menu_ID_Order_Item_Menu_Item` FOREIGN KEY (`Menu_ID`) REFERENCES `menu_item` (`Menu_ID`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_Order_ID_Order_Item_Order` FOREIGN KEY (`Order_ID`) REFERENCES `order` (`Order_ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `payment`
--
ALTER TABLE `payment`
  ADD CONSTRAINT `FK_Order_ID_Payment_Order` FOREIGN KEY (`Order_ID`) REFERENCES `order` (`Order_ID`) ON UPDATE CASCADE;

--
-- Constraints for table `superadmin`
--
ALTER TABLE `superadmin`
  ADD CONSTRAINT `FK_Em_ID_SuperAdmin_employee` FOREIGN KEY (`S_Em_ID`) REFERENCES `employee` (`Em_ID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
