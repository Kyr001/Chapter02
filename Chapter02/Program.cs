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
            public string Name;
            public string Job;
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

                //증감수치가 0일 때 코드 짜야함
                if (AtkUnD == 0)
                    Console.WriteLine("공격력 : {0} ", Atk);
                else
                    Console.WriteLine("공격력 : {0} (+{1})", AtkUnD, Atk);

                if (DefUnD == 0)
                    Console.WriteLine("방어력 : {0} ", Def);
                else
                    Console.WriteLine("방어력 : {0} (+{1})", DefUnD, Def);

                Console.WriteLine("체 력 : {0}", HP);
                Console.WriteLine("Gold : {0} G", Gold);
                Console.WriteLine();

                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                string input = Console.ReadLine();

                if (input == "0")
                    return;
            }
        }

        public class Item
        {
            public int ItemNum;
            public string Name;
            public string Effect;
            public int Stat;
            public string Detail;
            public int Price;
            public bool isEquiped;
            public bool isBought;

            public void IvenList()
            {

                //인벤: 보유O, 장착 상관없이 아이템 표시 / E표시 있음
                //Console.Write("- ");
                if (isEquiped == true)
                    Console.Write("[E]");
                Console.Write("{0}      | {1} +{2} | {3}", Name, Effect, Stat, Detail);
                Console.WriteLine();

                //장착 관리: 보유O, 장착 상관없이 아이템 표시 / E표시 있음 / 번호있음
            }

            public void StoreList()
            {

                //상점: 보유 상관없이 모든 아이템 표시 / 가격 or 구매완료 표시
                //Console.Write("- ");
                if (isEquiped == true)
                    Console.Write("[E]");
                Console.Write("{0}      | {1} +{2} | {3}", Name, Effect, Stat, Detail);
                if (isBought == true)
                    Console.Write("             |  구매완료");
                else
                    Console.Write("             |  {0} G", Price);
                Console.WriteLine();

                //상점: 보유 상관없이 모든 아이템 표시 / 가격 or 구매완료 표시 / 번호 있음

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

            //Console.Clear();

            int statUpDown = 0; // 스탯 증감치
            int iCount = 0; // 6가지 중에 보유중인 아이템 개수
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
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                input = Console.ReadLine();

                Console.Clear();
                switch (input)
                {
                    case "1":
                        StatUnD(p, I1);
                        p.ViewInfo();
                        break;
                    case "2":
                        ViewInven(I1);
                        break;
                    case "3":
                        ViewStore(p, I1);
                        break;
                    case "4":
                        Console.WriteLine("반복을 종료합니다.");
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            } while (input != "4");
        }

        static public void ViewInven(Item I1)
        {
            char type = '0';
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();

            //보유 중인 아이템을 표시
            Console.WriteLine("[아이템 목록]");
            if (I1.isBought)
            {
                Console.Write("- ");
                I1.IvenList();
            }

            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");

            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            string input = Console.ReadLine();

            if (input == "1")
                InvenManager(I1);
            else if (input == "0")
                return;
        }

        static public void InvenManager(Item I1)
        {
            string input;
            Console.Clear();
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();

            //아이템 앞에 번호 표시
            Console.WriteLine("[아이템 목록]");
            if (I1.isBought)
            {
                Console.Write("- {0} ", I1.ItemNum);
                I1.IvenList();
            }


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
                else if (input == "0")
                    return;
                else
                    Console.WriteLine("잘못된 입력입니다");
            } while (input != "0");
        }

        static public void ViewStore(Player p, Item I1)
        {
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();

            Console.WriteLine("[보유 골드]");
            Console.WriteLine("{0} G", p.Gold);
            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");
            I1.StoreList();

            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");

            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            string input = Console.ReadLine();

            if (input == "1")
                BuyItems(p, I1);
            else if (input == "0")
                return;
        }

        static public void BuyItems(Player p, Item I1)
        {
            string input;
            Console.Clear();
            Console.WriteLine("상점 - 아이템 구매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();

            Console.WriteLine("[보유 골드]");
            Console.WriteLine("{0} G", p.Gold);
            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");
            Console.Write("- {0} ", I1.ItemNum);
            I1.StoreList();

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

        static public void StatUnD(Player p, Item I1)
        {
            if(I1.isEquiped)
            {
                if (I1.Effect == "공격력")
                    p.AtkUnD = I1.Stat;
                if (I1.Effect == "방어력")
                    p.DefUnD = I1.Stat;
            }
        }
    }
}
