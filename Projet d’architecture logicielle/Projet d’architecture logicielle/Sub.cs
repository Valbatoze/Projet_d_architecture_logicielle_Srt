using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Projet_d_architecture_logicielle
{
    class Sub
    {
        //fonction qui devrais trouvais le temps parfais (Abandon)
        public int PerfectoTimingu(List<int> value)
        {
            int Timingu = 2000;
            int i = 0;

            for(int y = 0; y < value.Count; y++)
            {
                if (i != 9)
                {
                    Console.WriteLine(value[y]);
                    Console.WriteLine(y);
                    i++;
                }
            }

            return Timingu;
        }
        public async Task FindNum(string Line)
        {
            List<int> value = new List<int>();
            List<string> text = new List<string>();

            try
            {
                int val;
                //Cath de l'element et regarde si c'est un num 
                val = Int32.Parse(Line);

                //ajout des données dans la list
                value.Add(val);

                //Console.WriteLine(Line);
            }

            catch (FormatException)
            {
                //ajout des données dans la list
                text.Add(Line);
            }

            int time = PerfectoTimingu(value);

            Task t = Timetowait(time, text);
            await t;
        }

        public async Task FindTime(string Line)
        {
            //Charactère pour split et trouver le bon temp d'affichage du sous titre
            string[] split = Line.Split(new Char[] { '>', ',', ':', '-' });
            foreach (var element in split)
            {
                Task t = FindNum(element);
                await t;
            }
        }

        //fonction qui affiche mais await n'est pas pris en compte pourquoi ? ¯\_(ツ)_/¯
        public async Task Timetowait(int time, List<string> text)
        {
            foreach (var item in text)
            {
                //Console.WriteLine(item);
                await Task.Delay(time);
            }
        }

        public async Task DispSub()
        {
            //Début du chemin
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //Récuper le fichier srt
            using (StreamReader sr = new StreamReader(mydocpath + @"\Ynov\dote_net\Projet\Projet d’architecture logicielle\Projet d’architecture logicielle\Subtitle\Sub1.srt"))
            {
                string Line;
                //Affichage de tout le fichier en brute
                while ((Line = sr.ReadLine()) != null)
                {
                    Task t = FindTime(Line);
                    await t;
                }
            }
           // return Task.CompletedTask;
        }
    }
}
