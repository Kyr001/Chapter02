using System;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace Chapter02
{
    internal class Program
    {
        public class Player
        {
            public int Level;
            public string? Name;
            public string? Job;
            public int Atk;
            public int AtkUnD;
            public int Def;
            public int DefUnD;
            public int HP;
            public int Gold;

            public void ViewInfo()
            {
                string Lv = string.Format("{0:D2}", Level);

                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.WriteLine();
                Console.WriteLine("Lv. {0}", Lv);
                Console.WriteLine("{0} ( {1} )", Name, Job);

                if (AtkUnD == 0)
                    Console.WriteLine("공격력 : {0} ", Atk);
                else
                    Console.WriteLine("공격력 : {0} (+{1})", Atk + AtkUnD, AtkUnD );

                if (DefUnD == 0)
                    Console.WriteLine("방어력 : {0} ", Def);
                else
                    Console.WriteLine("방어력 : {0} (+{1})", Def + DefUnD, DefUnD);

                Console.WriteLine("체 력 : {0}", HP);
                Console.WriteLine("Gold : {0} G", Gold);
                Console.WriteLine();

                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                string? input = Console.ReadLine();

                if (input == "0")
                    return;
            }

            public void StatUnD(Item I)
            {
            }
        }

        public class Item
        {
            public int ItemNum;
            public string? Name;
            public string? Effect;
            public int Stat;
            public string? Detail;
            public int Price;
            public bool isEquiped;
            public bool isBought;
            public int Trigger;


            public void IvenList(char type)
            {
                if (type == '0' && isBought == true)
                    Console.Write("- ");
                else if (type == '1' && isBought == true)
                    Console.Write("- {0} ", ItemNum);
                else
                    return;

                if (isEquiped == true)
                    Console.Write("[E]");
                Console.Write("{0}      | {1} +{2} | {3}", Name, Effect, Stat, Detail);
                Console.WriteLine();
            }

            public void StoreList(char type)
            {
                if (type == '0')
                    Console.Write("- ");
                else if (type == '1')
                    Console.Write("- {0} ", ItemNum);
                else
                    return;

                if (isEquiped == true)
                    Console.Write("[E]");
                Console.Write("{0}      | {1} +{2} | {3}", Name, Effect, Stat, Detail);
                if (isBought == true)
                    Console.Write("             |  구매완료");
                else
                    Console.Write("             |  {0} G", Price);
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Player p = new Player();
            p.Level = 1;
            p.Name = "Chad";
            p.Job = "전사";
            p.Atk = 10;
            p.AtkUnD = 0;
            p.DefUnD = 0;
            p.Def = 5;
            p.HP = 100;
            p.Gold = 1500;

            Item I1 = new Item();
            I1.ItemNum = 1;
            I1.Name = "무쇠갑옷";
            I1.Effect = "방어력";
            I1.Stat = 5;
            I1.Detail = "무쇠로 만들어져 튼튼한 갑옷입니다.";
            I1.Price = 0;
            I1.isEquiped = false;
            I1.isBought = false;
            I1.Trigger = 0;

            Item I2 = new Item();
            I2.ItemNum = 2;
            I2.Name = "낡은 검";
            I2.Effect = "공격력";
            I2.Stat = 2;
            I2.Detail = "쉽게 볼 수 있는 낡은 검 입니다.";
            I2.Price = 600;
            I2.isEquiped = false;
            I2.isBought = false;
            I2.Trigger = 0;

            string input;

            do
            {
                Console.Clear();
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine("0. 종료");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        StatUnD(p, I1);
                        StatUnD(p, I2);
                        p.ViewInfo();
                        break;
                    case "2":
                        ViewInven(I1, I2);
                        break;
                    case "3":
                        ViewStore(p, I1, I2);
                        break;
                    case "0":
                        Console.WriteLine("게임을 종료합니다.");
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다. 잠시 후에 다시 입력하세요.");
                        Thread.Sleep(1000);
                        break;
                }
            } while (input != "0");
        }

        static public void ViewInven(Item I1, Item I2)
        {
            char type = '0';

            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();

            //보유 중인 아이템을 표시
            Console.WriteLine("[아이템 목록]");
            I1.IvenList(type);
            I2.IvenList(type);

            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");

            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            string? input = Console.ReadLine();

            if (input == "1")
                InvenManager(I1, I2);
            else if (input == "0")
                return;
        }

        static public void InvenManager(Item I1, Item I2)
        {
            char type = '1';
            string input;

            Console.Clear();
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();

            //아이템 앞에 번호 표시
            Console.WriteLine("[아이템 목록]");
            I1.IvenList(type);
            I2.IvenList(type);


            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            do
            {
                input = Console.ReadLine();

                if (input == "1")
                {
                    I1.isEquiped = (!I1.isEquiped) ? true : false;
                    return;
                }
                else if (input == "2")
                {
                    I2.isEquiped = (!I2.isEquiped) ? true : false;
                    return;
                }
                else if (input == "0")
                    return;
                else
                    Console.WriteLine("잘못된 입력입니다");
            } while (input != "0");
        }

        static public void ViewStore(Player p, Item I1, Item I2)
        {
            char type = '0';

            Console.Clear();
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();

            Console.WriteLine("[보유 골드]");
            Console.WriteLine("{0} G", p.Gold);
            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");
            I1.StoreList(type);
            I2.StoreList(type);

            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");

            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            string? input = Console.ReadLine();

            if (input == "1")
                BuyItems(p, I1, I2);
            else if (input == "0")
                return;
        }

        static public void BuyItems(Player p, Item I1, Item I2)
        {
            char type = '1';
            string input;

            Console.Clear();
            Console.WriteLine("상점 - 아이템 구매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();

            Console.WriteLine("[보유 골드]");
            Console.WriteLine("{0} G", p.Gold);
            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");
            I1.StoreList(type);
            I2.StoreList(type);

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            do
            {
                input = Console.ReadLine();

                if (input == "1")
                    if (!I1.isBought)
                        if (p.Gold < I1.Price)
                            Console.WriteLine("Gold가 부족합니다.");
                        else
                        {
                            I1.isBought = true;
                            p.Gold -= I1.Price;;
                            return;
                        }
                    else
                        Console.WriteLine("이미 구매한 아이템입니다.");

                else if (input == "2")
                    if (!I2.isBought)
                        if (p.Gold < I2.Price)
                            Console.WriteLine("Gold가 부족합니다.");
                        else
                        {
                            I2.isBought = true;
                            p.Gold -= I2.Price; ;
                            return;
                        }
                    else
                        Console.WriteLine("이미 구매한 아이템입니다.");

                else
               {
                   Console.WriteLine("잘못된 입력입니다.");
               }
            } while (input != "0");
        }

        static public void StatUnD(Player p, Item I)
        {
            //trigger로 이전 반복에서 장착돼 있는지 아닌지 판단함
            if (I.Trigger == 0 && I.isEquiped)
            {
                if (I.Effect == "공격력")
                    p.AtkUnD += I.Stat;
                if (I.Effect == "방어력")
                    p.DefUnD += I.Stat;
                I.Trigger = 1;
            }
            else if (I.Trigger == 1 && !I.isEquiped)
            {
                if (I.Effect == "공격력")
                    p.AtkUnD -= I.Stat;
                if (I.Effect == "방어력")
                    p.DefUnD -= I.Stat;
                I.Trigger = 0;
            }
            else
                return;
        }
    }
}
