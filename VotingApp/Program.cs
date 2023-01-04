//Voting Uygulaması
//Uygulama çalıştığında pre-defined olarak belirlenen kategoriler oylamaya sunulmak üzere listelenmelidir. Yalnızca sisemde kayırlı olan kullanıcılar oy verebilir. Oylama sırasında öncelikle kullanıcının username'i istenmelidir. Eğer sistemde kayıtlı değilse kayıt olmasına imkan sağlanmalı ve kaldığı yerden oylamaya devam edebilmelidir. Kategoriler isteğe bağlı olarak belirlenebilir.

//Bazı Örnek Kategoriler: Film Kategorileri Tech Stack Kategorileri Spor Kategorileri

//Son olarak uygulama sonlandırılırken, Voting sonuçları hem rakamsal hem de yüzdesel olarak gösterilmelidir.

//Kullanılması gereken teknikler:

//Kategoriler pre-defined kullanılabilir.



using static VotingApp.Category;
using static VotingApp.User;

namespace VotingApp
{
    public class Program
    {
        static string username = "";
        static string password = "";
        private static bool loggedIn = false;
        private static bool isVoted = false;
        static int i=0;

        static void Main(string[] args)
        {

            Calistir();
        }
        public static void Calistir()
        {
            if (!loggedIn)
                Giris();

            if (loggedIn)
            {
            Start:
                while (!isVoted)
                {
                    Console.WriteLine("Oy vermek istediğiniz kategoriyi seçiniz:");
                    foreach (var item in Categories.catList)
                    {
                        Console.WriteLine(item.CatId + " " + item.CatName + " - toplam oy: " + item.CatVote);
                    }
                    Console.WriteLine();
                    Console.WriteLine("0 Exit");
                    i = Int32.Parse(Console.ReadLine());
                    if (Categories.catList.Count >= i && i !=0)
                    {
                        Categories GetCatty = GetCat(i);
                        GetCatty.addVote();
                        isVoted = User.UserList.Find(x => x.UserName == username).voted;
                        isVoted = true;
                    }
                    else if(i==0)
                    {
                        KategorileriEkranaYaz();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("xxxxx Kategori bulunamadı! xxxxx");
                        Console.WriteLine();
                        goto Start;
                    }
                }
                if (isVoted)
                {
                    Console.WriteLine("----- Oyunuz başarıyla kaydedildi. -----");
                    Console.WriteLine();
                    isVoted = false;
                }
                if(i!=0)
                goto Start;
            }
            else
            {
                Console.WriteLine("Önce Giriş Yapınız");
            }
        }
        public static void KategorileriEkranaYaz()
        {
            double yuzde = 0;
            foreach(var item in Categories.catList)
            {
                if (item.CatVote != 0)
                {
                    yuzde += item.CatVote;
                }
                else
                    break;
            }
            foreach (var item in Categories.catList)
            {
                Console.WriteLine(item.CatId + " " + item.CatName + " - toplam oy: " + item.CatVote + " yüzde: %" + ((item.CatVote/yuzde)*100));
            }
        }
        public static Categories GetCat(int catId)
        {
            return Categories.catList.Find(x => x.CatId == catId);

        }


        public static bool isUserExists(string userName)
        {
            foreach (User item in User.UserList)
            {
                if (item.UserName == userName)
                {
                    return true;
                }
            }
            return false;
        }

        public static void AddUser()
        {
            System.Console.WriteLine("Oluşturmak istediğiniz kullanıcı adınızı giriniz:");
            string userName = Console.ReadLine();
            System.Console.WriteLine("Parolanızı giriniz:");
            string password = Console.ReadLine();
            bool voted = false;
            isVoted = voted;
            User.UserList.Add(new User(userName, password, voted));
            loggedIn = true;
        }

        public static void Giris()
        {
            Console.WriteLine("Kullanıcı adınızı giriniz: ");
            username = Console.ReadLine();
            Console.WriteLine("şifrenizi giriniz: ");
            password = Console.ReadLine();
            if (User.UserList.Exists(x => x.UserName == username && x.Password == password))
            {
                Console.WriteLine("Hoşgeldin " + username + "!");
                Console.WriteLine();
                loggedIn = true;


            }
            else
            {
                Console.WriteLine("Kullanıcı adı veya şifre bulunamadı!");
                AddUser();
                Calistir();

            }

        }
    }

}