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

                Console.Clear();
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
                //trigger로 이전 반복에서 장착돼 있는지 아닌지 판단함
                if (I.Trigger == 0 && I.isEquiped)
                {
                    if (I.Effect == "공격력")
                        AtkUnD += I.Stat;
                    if (I.Effect == "방어력")
                        DefUnD += I.Stat;
                    I.Trigger = 1;
                }
                else if (I.Trigger == 1 && !I.isEquiped)
                {
                    if (I.Effect == "공격력")
                        AtkUnD -= I.Stat;
                    if (I.Effect == "방어력")
                        DefUnD -= I.Stat;
                    I.Trigger = 0;
                }
                else
                    return;
            }
        }

        public class Item
        {
            public string? Name;
            public string? Effect;
            public int Stat;
            public string? Detail;
            public int Price;
            public bool isEquiped;
            public bool isBought;
            public int Trigger;

            public void IvenList()
            {
                if (isEquiped == true)
                    Console.Write("[E]");
                Console.Write("{0} | {1} +{2} | {3}", Name, Effect, Stat, Detail);
                Console.WriteLine();
            }

            public void StoreList()
            {
                if (isEquiped == true)
                    Console.Write("[E]");
                Console.Write("{0} | {1} +{2} | {3}", Name, Effect, Stat, Detail);
                if (isBought == true)
                    Console.Write("|  구매완료");
                else
                    Console.Write("|  {0} G", Price);
                Console.WriteLine();
            }

            public void Buy(Player p)
            {
                if (!isBought)
                    if (p.Gold < Price)
                        Console.WriteLine("Gold가 부족합니다.");
                    else
                    {
                        isBought = true;
                        p.Gold -= Price; ;
                        Console.WriteLine("구매를 완료했습니다.");
                    }
                else
                    Console.WriteLine("이미 구매한 아이템입니다.");

                Console.WriteLine("시작 화면으로 돌아갑니다.");
                Thread.Sleep(2000);
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

            Item[] I = new Item[6];

            Item I0 = new Item();
            I0.Name = "수련자 갑옷   ";
            I0.Effect = "방어력";
            I0.Stat = 5;
            I0.Detail = "수련에 도움을 주는 갑옷입니다.             ";
            I0.Price = 1000;
            I0.isEquiped = false;
            I0.isBought = false;
            I0.Trigger = 0;

            I[0] = I0;
            Item I1 = new Item();
            I1.Name = "무쇠갑옷     ";
            I1.Effect = "방어력";
            I1.Stat = 9;
            I1.Detail = "무쇠로 만들어져 튼튼한 갑옷입니다.           ";
            I1.Price = 0;
            I1.isEquiped = false;
            I1.isBought = false;
            I1.Trigger = 0;
            I[1] = I1;

            Item I2 = new Item();
            I2.Name = "스파르타의 갑옷";
            I2.Effect = "방어력";
            I2.Stat = 15;
            I2.Detail = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.";
            I2.Price = 3500;
            I2.isEquiped = false;
            I2.isBought = false;
            I2.Trigger = 0;
            I[2] = I2;

            Item I3 = new Item();
            I3.Name = "낡은 검     ";
            I3.Effect = "공격력";
            I3.Stat = 2;
            I3.Detail = "쉽게 볼 수 있는 낡은 검 입니다.            ";
            I3.Price = 600;
            I3.isEquiped = false;
            I3.isBought = false;
            I3.Trigger = 0;
            I[3] = I3;

            Item I4 = new Item();
            I4.Name = "청동 도끼    ";
            I4.Effect = "공격력";
            I4.Stat = 5;
            I4.Detail = "어디선가 사용됐던거 같은 도끼입니다.        ";
            I4.Price = 1500;
            I4.isEquiped = false;
            I4.isBought = false;
            I4.Trigger = 0;
            I[4] = I4;

            Item I5 = new Item();
            I5.Name = "스파르타의 창 ";
            I5.Effect = "공격력";
            I5.Stat = 7;
            I5.Detail = "스파르타의 전사들이 사용했다는 전설의 창입니다. ";
            I5.Price = 0;
            I5.isEquiped = false;
            I5.isBought = false;
            I5.Trigger = 0;
            I[5] = I5;


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
                        p.StatUnD(I[0]);
                        p.StatUnD(I[1]);
                        p.StatUnD(I[2]);
                        p.StatUnD(I[3]);
                        p.StatUnD(I[4]);
                        p.StatUnD(I[5]);
                        p.ViewInfo();
                        break;
                    case "2":
                        ViewInven(I);
                        break;
                    case "3":
                        ViewStore(p, I);
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

        static public void ViewInven(Item[] I)
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();

            //보유 중인 아이템을 표시
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < I.Length; i++)
            {
                if (I[i].isBought)
                {
                    Console.Write("- ");
                    I[i].IvenList();
                }
            }

            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");

            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            string? input = Console.ReadLine();

            if (input == "1")
                InvenManager(I);
            else if (input == "0")
                return;
        }

        static public void InvenManager(Item[] I)
        {
            string input;

            Console.Clear();
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();

            //아이템 앞에 번호 표시
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < I.Length; i++)
            {
                if (I[i].isBought)
                {
                    Console.Write("- {0} ", i + 1);
                    I[i].IvenList();
                }
            }

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            do
            {
                input = Console.ReadLine();
                switch(input)
                {
                    case "1":
                        I[0].isEquiped = (!I[0].isEquiped) ? true : false;
                        return;
                    case "2":
                        I[1].isEquiped = (!I[1].isEquiped) ? true : false;
                        return;

                    case "3":
                        I[2].isEquiped = (!I[2].isEquiped) ? true : false;
                        return;
                    case "4":
                        I[3].isEquiped = (!I[3].isEquiped) ? true : false;
                        return;

                    case "5":
                        I[4].isEquiped = (!I[4].isEquiped) ? true : false;
                        return;
                    case "6":
                        I[5].isEquiped = (!I[5].isEquiped) ? true : false;
                        return;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("잘못된 입력입니다. 다시 입력하세요.");
                        break;
                }

            } while (input != "0");
        }

        static public void ViewStore(Player p, Item[] I)
        {

            Console.Clear();
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();

            Console.WriteLine("[보유 골드]");
            Console.WriteLine("{0} G", p.Gold);
            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < I.Length; i++)
            {
                Console.Write("- ");
                I[i].StoreList();
            }

            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");

            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            string? input = Console.ReadLine();

            if (input == "1")
                BuyItems(p, I);
            else if (input == "0")
                return;
        }

        static public void BuyItems(Player p, Item[] I)
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
            for (int i = 0; i < I.Length; i++)
            {
                Console.Write("- {0} ", i + 1);
                I[i].StoreList();
            }

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            do
            {
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        I[0].Buy(p);
                        return;
                    case "2":
                        I[1].Buy(p);
                        return;

                    case "3":
                        I[2].Buy(p);
                        return;
                    case "4":
                        I[3].Buy(p);
                        return;

                    case "5":
                        I[4].Buy(p);
                        return;
                    case "6":
                        I[5].Buy(p);
                        return;

                    case "0":
                        return;
                    default:
                        Console.WriteLine("잘못된 입력입니다. 다시 입력하세요.");
                        break;
                }
            } while (input != "0");

        }
    }
}
