using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.UIHandler
{
    public static class PaymentPopup
    {
        public static string Show()
        {
            using (Form popup = new Form())
            {
                popup.Width = 320;
                popup.Height = 160;
                popup.FormBorderStyle = FormBorderStyle.FixedDialog;
                popup.StartPosition = FormStartPosition.CenterParent;
                popup.Text = "Select Payment";

                Label lbl = new Label()
                {
                    Text = "Choose payment method:",
                    AutoSize = true,
                    Top = 20,
                    Left = 20
                };
                popup.Controls.Add(lbl);

                string choice = "Cancel"; // default if closed

                Button btnCash = new Button()
                {
                    Text = "Cash",
                    Top =  lbl.Bottom + 20,
                    Left = 20
                };
                btnCash.Click += (s, e) =>
                {
                    choice = "Cash";
                    popup.DialogResult = DialogResult.OK;
                    popup.Close();
                };
                popup.Controls.Add(btnCash);

                Button btnCard = new Button()
                {
                    Text = "Card",
                    Top = lbl.Bottom + 20,
                    Left = btnCash.Right + 20
                };
                btnCard.Click += (s, e) =>
                {
                    choice = "Card";
                    popup.DialogResult = DialogResult.OK;
                    popup.Close();
                };
                popup.Controls.Add(btnCard);

                Button btnCancel = new Button()
                {
                    Text = "Cancel",
                    Top = lbl.Bottom + 20,
                    Left = btnCard.Right + 20,
                    DialogResult = DialogResult.Cancel
                };
                popup.Controls.Add(btnCancel);
                btnCash.Height = 40;
                btnCard.Height = 40;
                btnCancel.Height = 40;
                popup.ShowDialog(); // show the popup

                return choice; // returns "Cash", "Card", or "Cancel"
            }
        }
    }
}
