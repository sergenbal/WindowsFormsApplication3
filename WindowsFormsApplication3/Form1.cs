using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//sbal
//KNN ALGORİTMASI classifty
namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        int degisken;
        List<Koordinat> koordinatliste = new List<Koordinat>();
       
        public Form1()
        {
            InitializeComponent();
            listeyeİlkElemanAta();
        }
        public void listeyeİlkElemanAta()
        {
            //listeye hazır elemanlar koyma
            Koordinat kor1 = new Koordinat();
            Koordinat kor2 = new Koordinat();
            Koordinat kor3 = new Koordinat();
            Koordinat kor4 = new Koordinat();

            kor1.X = 7; kor1.Y = 7; kor1.Sinif = "sinif1";
            koordinatliste.Add(kor1);

            kor2.X = 7; kor2.Y = 4; kor2.Sinif = "sinif1";
            koordinatliste.Add(kor2);

            kor3.X = 3; kor3.Y = 4; kor3.Sinif = "sinif2";
            koordinatliste.Add(kor3);

            kor4.X = 1; kor4.Y = 4; kor4.Sinif = "sinif2";
            koordinatliste.Add(kor4);

            //listeyi görüntüleme
            foreach (Koordinat kullanici in koordinatliste)
            {
                listBox1.Items.Add(kullanici.X + " " + kullanici.Y + " " + kullanici.Sinif);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Koordinat kor = new Koordinat();
           
            
            List<Uzaklik> uzaklikliste = new List<Uzaklik>();
           

            listBox2.Items.Clear();
            listBox3.Items.Clear();
            try
            {
                 kor.X = int.Parse(textBox1.Text);
                 kor.Y = int.Parse(textBox2.Text);
                //x y korrdinatlarını alma
            }
            catch (Exception)
            {

                throw;
            }
           
          
            for (int i = 0; i < koordinatliste.Count(); i++)
            {
                // yeni alınan deger ile listeki degerler arasındaki oklıd uzaklıgını bulma
                Uzaklik uza = new Uzaklik();
                uza.Deger = Math.Round(Math.Sqrt(Math.Pow(koordinatliste[i].X - kor.X, 2) + Math.Pow(koordinatliste[i].Y - kor.Y, 2)),3);
                uza.Nesne = koordinatliste[i].Sinif;             
                uzaklikliste.Add(uza);
                         
            }
            
            for (int i = 0; i < uzaklikliste.Count(); i++)
            {
                listBox2.Items.Add(uzaklikliste[i].Deger + " " + uzaklikliste[i].Nesne);
            }        

            // kücükten büyüge sıralama
            for (int i = 0; i < uzaklikliste.Count()-1; i++)
            {
                for (int j = 1; j < uzaklikliste.Count()-i; j++)
                {
                    if(uzaklikliste[j].Deger < uzaklikliste[j - 1].Deger)
                    {
                        Uzaklik u = uzaklikliste[j - 1];
                        uzaklikliste[j - 1] = uzaklikliste[j];
                        uzaklikliste[j] = u;
                    }
                }
            }
            for (int i = 0; i < uzaklikliste.Count(); i++)
            {
                listBox3.Items.Add(uzaklikliste[i].Deger + " " + uzaklikliste[i].Nesne);
            }


            int a = 0; int b = 0;
            int KK = int.Parse(txt_Kdegeri.Text);
            if (KK <= koordinatliste.Count())
            {
                for (int i = 0; i < KK; i++)
                {
                    //hangi sınıfa ait oldugunu bulma
                    if (uzaklikliste[i].Nesne == "sinif1") a++;
                    if (uzaklikliste[i].Nesne == "sinif2") b++;
                }
                //kime daha yakın ise o sınıfa koyma
                if (a > b)
                {
                    kor.Sinif = "sinif1";
                }
                else if (a < b)
                {
                    kor.Sinif = "sinif2";
                }
                else
                {
                    kor.Sinif = uzaklikliste[0].Nesne;
                }
                koordinatliste.Add(kor);
                listBox1.Items.Clear();

                foreach (Koordinat kullanici in koordinatliste)
                {
                    listBox1.Items.Add(kullanici.X + " " + kullanici.Y + " " + kullanici.Sinif);
                }
            }
            else
            {
                MessageBox.Show("K değeri eleman değerinden fazla olamaz. Lütfen " + koordinatliste.Count() + "'e esit veya kücük deger giriniz.");
            }
        }

      
    }

   
}
