using System;
using System.Windows.Forms;

namespace ProcedureGenerator
{
    public partial class Procedure_Generator : Form
    {
        private bool isGenerated = false;

        public Procedure_Generator()
        {
            InitializeComponent();
        }

        private void Generate_btn_Click(object sender, EventArgs e)
        {
            int size = ToTexture2D.Convert(Int32.Parse(WorldGrad.Text));
            int seed = Int32.Parse(Seed_Box.Text);

            if (isGenerated && !Controller.isNewMap(seed, size))
            {
                Controller.LoadFullMap();
                WorldPicture.Image = Controller.ControlImage;
                return;
            }
            isGenerated = true;
            int x, y;
            if (!(Int32.TryParse(PosX.Text, out x) && Int32.TryParse(PosY.Text, out y)))
                return;
            WorldPicture.Size = new System.Drawing.Size(size, size);
            WorldPicture.BorderStyle = BorderStyle.Fixed3D;
            Controller.StartWork(x, y, size, seed, MiniMapMode.Checked);
            WorldPicture.Image = Controller.ControlImage;

            ChunkX.Text = String.Format("{0}", Controller.player.ChunkX);
            ChunkY.Text = String.Format("{0}", Controller.player.ChunkY);
            PosX.Text = String.Format("{0}", Controller.player.x);
            PosY.Text = String.Format("{0}", Controller.player.y);
        }

        private void WorldGrad_TextChanged(object sender, EventArgs e)
        {
            char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char lastchar = WorldGrad.Text[WorldGrad.Text.Length - 1];
            if (Array.IndexOf(numbers, lastchar) == -1)
                WorldGrad.Text = WorldGrad.Text.Substring(0, WorldGrad.Text.Length - 2);
            if (Int32.Parse(WorldGrad.Text) > 10)
                WorldGrad.Text = "10";
            if (Int32.Parse(WorldGrad.Text) < 4)
                WorldGrad.Text = "8";
        }

        private void ChangeCord_Click(object sender, EventArgs e)
        {
            if (isGenerated)
            {
                int x, y;
                if (Int32.TryParse(PosX.Text, out x) && Int32.TryParse(PosY.Text, out y))
                    Controller.PlayerMoved(x, y, true);
                WorldPicture.Image = Controller.ControlImage;
                ChunkX.Text = String.Format("{0}", Controller.player.ChunkX);
                ChunkY.Text = String.Format("{0}", Controller.player.ChunkY);
                PosX.Text = String.Format("{0}", Controller.player.x);
                PosY.Text = String.Format("{0}", Controller.player.y);
            }
        }

        private void Procedure_Generator_KeyDown(object sender, KeyEventArgs e)
        {
            if (isGenerated)
            {
                if (e.KeyCode == Keys.Left)
                    Controller.PlayerMoved(-1, 0, false);
                else if (e.KeyCode == Keys.Right)
                    Controller.PlayerMoved(1, 0, false);
                else if (e.KeyCode == Keys.Up)
                    Controller.PlayerMoved(0, -1, false);
                else if (e.KeyCode == Keys.Down)
                    Controller.PlayerMoved(0, 1, false);
                else
                    return;

                WorldPicture.Image = Controller.ControlImage;
                WorldPicture.Update();

                ChunkX.Text = String.Format("{0}", Controller.player.ChunkX);
                ChunkY.Text = String.Format("{0}", Controller.player.ChunkY);
                PosX.Text = String.Format("{0}", Controller.player.x);
                PosY.Text = String.Format("{0}", Controller.player.y);
            }
        }

        private void MiniMapMode_CheckedChanged(object sender, EventArgs e)
        {
            if (isGenerated)
            {
                Controller.MiniMapMode = MiniMapMode.Checked;
                Controller.ChangedMode();
                WorldPicture.Image = Controller.ControlImage;
            }
        }

        private void Procedure_Generator_Load(object sender, EventArgs e)
        {

        }
    }
}