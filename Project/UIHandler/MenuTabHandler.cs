using Project.TableHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project.UIHandler
{
    internal class MenuTabHandler
    {
        TabControl tabControl;
        AddOrderUI1 addOrderUI;

        public MenuTabHandler(TabControl tabCont, AddOrderUI1 addOrd)
        {
            tabControl = tabCont;
            addOrderUI = addOrd;
        }

        public void setupTabControl(List<Category> categoryList, List<Menu_item> menuItemList)
        {
            tabControl.TabPages.Clear();

            foreach (Category c in categoryList)
            {
                var tab = new TabPage { Text = c.Name };
                populateTabPage(menuItemList, c, tab);
                tabControl.TabPages.Add(tab);
            }
        }

        public void populateTabPage(List<Menu_item> menuItemList, Category c, TabPage tab)
        {
            tab.Controls.Clear();

            FlowLayoutPanel tabPanel = new FlowLayoutPanel();
            tabPanel.Dock = DockStyle.Fill;
            tabPanel.AutoScroll = true;
            tabPanel.WrapContents = true;
            tabPanel.FlowDirection = FlowDirection.LeftToRight;

            foreach (Menu_item m in menuItemList)
            {
                if (m.Category_ID != c.Category_id) continue;

                Panel itemPanel = new Panel();
                itemPanel.Width = 140;
                itemPanel.Height = 160;
                itemPanel.Margin = new Padding(5);
                itemPanel.BorderStyle = BorderStyle.FixedSingle;

                PictureBox pb = new PictureBox();
                pb.Width = 140;
                pb.Height = 100;
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                if (!string.IsNullOrEmpty(m.Path))
                {
                    pb.Image = getImageFromPath(m.Path);
                }
                itemPanel.Controls.Add(pb);

                Label lblName = new Label();
                lblName.Text = m.Name;
                lblName.Top = pb.Bottom;
                lblName.Width = 140;
                lblName.Height = 30;
                lblName.TextAlign = ContentAlignment.MiddleCenter;
                itemPanel.Controls.Add(lblName);

                Label lblPrice = new Label();
                lblPrice.Text = m.Price.ToString("C");
                lblPrice.Top = lblName.Bottom;
                lblPrice.Width = 140;
                lblPrice.Height = 30;
                lblPrice.TextAlign = ContentAlignment.MiddleCenter;
                itemPanel.Controls.Add(lblPrice);

                itemPanel.MouseDown += (s, e) => MenuItemClicked(m.Menu_id, m.Name, m.Price);

                foreach (Control child in itemPanel.Controls)
                {
                    child.MouseDown += (s, e) => MenuItemClicked(m.Menu_id, m.Name, m.Price);
                }

                tabPanel.Controls.Add(itemPanel);
            }

            tab.Controls.Add(tabPanel);
        }

        private void MenuItemClicked(uint menuItemId, string menuItemName, decimal price)
        {
            addOrderUI.addOrder(menuItemId, menuItemName, 1, price);
        }

        // I pray to whoever needed to update my codes 🙏🙏🙏🙏🙏
        private Image? getImageFromPath(string? relativePath)
        {
            string projectFolder = Path.GetFullPath(Path.Combine(Application.StartupPath, "..", "..", ".."));
            string placeholderPath = Path.Combine(projectFolder, "Resources", "placeholder.jpg");

            string? firstPath = string.IsNullOrEmpty(relativePath) ? null : Path.Combine(projectFolder, relativePath);

            foreach (var path in new[] { firstPath, placeholderPath })
            {
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                {
                    try
                    {
                        using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                        using var img = Image.FromStream(fs);
                        return new Bitmap(img);
                    }
                    catch
                    {

                    }
                }
            }
            return null;
        }
    }
}