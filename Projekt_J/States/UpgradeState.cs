using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Projekt_J.States
{
    internal class UpgradeState : GameState
    {
        private PlayerCastle playerCastle;
        private List<List<PictureBox>> castleLvls = new List<List<PictureBox>>() {new List<PictureBox>(), new List<PictureBox>()};
        private List<PictureBox> pictureBoxes = new List<PictureBox>() {new PictureBox(), new PictureBox(), new PictureBox(), new PictureBox(), new PictureBox(), new PictureBox(), new PictureBox() };
        private List<Label> labels = new List<Label>() { new Label(), new Label(), new Label(), new Label(), new Label(), new Label(), new Label() };
        private GameState newState;
        public UpgradeState(Form parrentform, GameState previousState, PlayerCastle playerCastle) : base(parrentform, previousState, playerCastle)
        {
            newState = this;
            this.playerCastle = playerCastle;
            //creating lists for castle levels
                //tier 2 Castle
                PictureBox tier2Castle = new PictureBox();
                tier2Castle.Image = Properties.Resources.Castle_tier2;
                castleLvls[0].Add(tier2Castle);
                PictureBox tier2Castle_dmg = new PictureBox();
                tier2Castle_dmg.Image = Properties.Resources.Castle_tier2_dmg;
                castleLvls[0].Add(tier2Castle_dmg);
                //tier 3 Castle
                PictureBox tier3Castle = new PictureBox();
                tier3Castle.Image = Properties.Resources.Castle_tier3;
                castleLvls[1].Add(tier3Castle);
                PictureBox tier3Castle_dmg = new PictureBox();
                tier3Castle_dmg.Image = Properties.Resources.Castle_tier3_dmg;
                castleLvls[1].Add(tier3Castle_dmg);

            //

            //back button
            pictureBoxes[0] = new PictureBox();
            pictureBoxes[0].BackColor = Color.Transparent;
            pictureBoxes[0].Image = Properties.Resources.Purple_Button;
            pictureBoxes[0].SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxes[0].Left = 473;
            pictureBoxes[0].Top = 562;
            pictureBoxes[0].MouseClick += new MouseEventHandler((s, e) => Back_Click());

            //castle Icon
            pictureBoxes[1] = new PictureBox();
            pictureBoxes[1].SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxes[1].Size = new Size(122, 84);
            pictureBoxes[1].BackColor = Color.Transparent;
            pictureBoxes[1].Left = 135;
            pictureBoxes[1].Top = 327;

            //castle button
            pictureBoxes[2] = new PictureBox();
            pictureBoxes[2].SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxes[2].Image = Properties.Resources.Green_Button;
            pictureBoxes[2].BackColor = Color.Transparent;
            pictureBoxes[2].Left = 91;
            pictureBoxes[2].Top = 417;
            pictureBoxes[2].MouseClick += new MouseEventHandler((s, e) => UpgradeCastle_Click());

            //attack icon
            pictureBoxes[3] = new PictureBox();
            pictureBoxes[3].Image = Properties.Resources.Attack_dmg;
            pictureBoxes[3].BackColor = Color.Transparent;
            pictureBoxes[3].Left = 507;
            pictureBoxes[3].Top = 327;
            pictureBoxes[3].SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxes[3].Size = new Size(149, 84);

            //attack button
            pictureBoxes[4] = new PictureBox();
            pictureBoxes[4].Image = Properties.Resources.Green_Button;
            pictureBoxes[4].BackColor = Color.Transparent;
            pictureBoxes[4].SizeMode=PictureBoxSizeMode.AutoSize;
            pictureBoxes[4].Left = 473;
            pictureBoxes[4].Top = 417;
            pictureBoxes[4].MouseClick += new MouseEventHandler((s, e) => UpgradeClickDamge_Click());

            //units Icon
            pictureBoxes[5] = new PictureBox();
            pictureBoxes[5].Image = Properties.Resources.Elf_01;
            pictureBoxes[5].BackColor = Color.Transparent;
            pictureBoxes[5].Size = new Size(100, 84);
            pictureBoxes[5].Left = 868;
            pictureBoxes[5].Top = 327;

            //units button
            pictureBoxes[6] = new PictureBox();
            pictureBoxes[6].Image = Properties.Resources.Green_Button;
            pictureBoxes[6].BackColor = Color.Transparent;
            pictureBoxes[6].SizeMode= PictureBoxSizeMode.AutoSize;
            pictureBoxes[6].Left = 809;
            pictureBoxes[6].Top = 417;
            pictureBoxes[6].MouseClick += new MouseEventHandler((s, e) => UpgradeUnits_Click());

            labels[0] = new Label();
            labels[0].BackColor = Color.Transparent;
            labels[0].Left = 445;
            labels[0].Top = 215;
            labels[0].Font = new Font("Calibri", 26, FontStyle.Bold);
            labels[0].Text = $"Avaiable Points: {playerCastle.AvaiablePoints}";
            labels[0].Size = new Size(300, 42);

            labels[1] = new Label();
            labels[1].BackColor = Color.Transparent;
            labels[1].Left = 145;
            labels[1].Top = 291;
            labels[1].Font = new Font("Calibri", 18, FontStyle.Bold);
            labels[1].Text = $"Level: {playerCastle.CastleLevel}/3";
            labels[1].Size = new Size(111, 29);

            labels[2] = new Label();
            labels[2].BackColor = Color.Transparent;
            labels[2].Image = Properties.Resources.Green_Button;
            labels[2].Text = "Upgrade Castle";
            labels[2].Left = 146;
            labels[2].Top = 450;
            labels[2].Font = new Font("Calibri",12,FontStyle.Bold);
            labels[2].Width = 113;


            labels[3] = new Label();
            labels[3].BackColor = Color.Transparent;
            labels[3].Left = 524;
            labels[3].Top = 291;
            labels[3].Font = new Font("Calibri", 18, FontStyle.Bold);
            labels[3].Text = $"Level: {playerCastle.AttackLvl}/5";
            labels[3].Size = new Size(111, 29);

            labels[4] = new Label();
            labels[4].BackColor = Color.Transparent;
            labels[4].Image = Properties.Resources.Green_Button;
            labels[4].Font = new Font("Calibri", 12, FontStyle.Bold);
            labels[4].Left = 503;
            labels[4].Top = 450;
            labels[4].Text = "Upgrade Click Damage";
            labels[4].Width = 165;


            labels[5] = new Label();
            labels[5].BackColor = Color.Transparent;
            labels[5].Left = 856;
            labels[5].Top = 291;
            labels[5].Font = new Font("Calibri", 18, FontStyle.Bold);

            labels[6] = new Label();
            labels[6].BackColor = Color.Transparent;
            labels[6].Image = Properties.Resources.Green_Button;
            labels[6].Font = new Font("Calibri", 12, FontStyle.Bold);
            labels[6].Left = 864;
            labels[6].Top = 450;
            labels[6].Text = "Upgrade Units";
            labels[6].Width = 110;
            


            foreach(PictureBox picture in pictureBoxes)
            {
                parrentform.Controls.Add(picture);
            }
            foreach(Label label in labels)
            {
                parrentform.Controls.Add(label);
                label.BringToFront();
            }


        }

        public override GameState Run()
        {
            pictureBoxes[1].Image = playerCastle.HitBox.Image;
            labels[0].Text = $"Avaiable Points: {playerCastle.AvaiablePoints}";
            labels[1].Text = $"Level: {playerCastle.CastleLevel}/3";
            labels[3].Text = $"Level: {playerCastle.AttackLvl}/5";
            return newState;
        }


        private void UpgradeCastle_Click()
        {
            if (playerCastle.CastleLevel < 3)
            {
                playerCastle.UpgradeCastle(castleLvls[playerCastle.CastleLevel - 1] != null ? castleLvls[playerCastle.CastleLevel - 1] : castleLvls[1]);
            }
        }

        private void UpgradeClickDamge_Click()
        {
            if (playerCastle.AttackLvl < 5)
            {
                playerCastle.UpgradeDamge();
            }
        }

        private void UpgradeUnits_Click()
        {

        }

        private void Back_Click()
        {
            HideGUI();
            previousState.ShowGUI();
            newState = previousState;
        }

        public override void HideGUI()
        {
            foreach (PictureBox picture in pictureBoxes)
            {
                picture.Hide();
            }
            foreach (Label label in labels)
            {
                label.Hide();
            }
        }

        public override void ShowGUI()
        {
            foreach (PictureBox picture in pictureBoxes)
            {
                picture.Show();
            }
            foreach (Label label in labels)
            {
                label.Show();
            }
        }
    }
}
