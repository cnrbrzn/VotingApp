using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp
{
    public class Category
    {
        public class Categories
        {
            private int catId;
            private string catName;
            private int catVote;
            private int sayac = 0;
            public static List<Categories> catList = new List<Categories>()
            {
                new Categories {catId=1,catName="Film",catVote=0,sayac=0 },
                new Categories {catId=2,catName="Tech",catVote=0,sayac=0 },
                new Categories {catId=3,catName="Spor",catVote=0,sayac=0 }
            };

            public int CatId { get => catId; set => catId = value; }
            public string CatName { get => catName; set => catName = value; }
            public int CatVote { get => catVote; set => catVote = value; }

            public Categories()
            {

            }
            public Categories(string catName)
            {
                this.CatName = catName;
                if(catList.Count == 0) { 
                    sayac++;
                }
                catId = catList.Count+1;
                catList.Add(this);
            }

            public void addVote()
            {
                catVote++;
                CatVote = catVote;
            }

        }
    }
}
