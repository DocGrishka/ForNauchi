using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Generate : MonoBehaviour
{

    public Dropdown Locations_dropDown;//âûïàäàþùèé ñïèñîê ëîêàöèé
    public Dropdown WorldType_dropDown;//âûïàäàþùèé ñïèñîê òèïîâ ïàðòèé
    public GameObject Content_UnplayableCharacters;
    public GameObject Content_MainObjects;
    private Vector3 FirstWidnowEndPosition;
    //int string
    int Rule = 0;
    int[] Characters = new int[30];
    int[] KeyObj = new int[30];
    int CountCharacter = 0;
    int CountKeyObj = 0;
    public GameObject StartMenu;
    public float speed = 10.0F;
    bool StartMenu_move = false;
    bool Location_move = false;
    public List<string> Locations = new List<string>();
    public List<string> WorldTypes = new List<string>();
    public List<string> UnplayableCharacters_List = new List<string>();
    public List<string> MainObjects_List = new List<string>();
    public Toggle example;
    public int move;
    public Text BeforeVerdict;
    public int Page = 1;
    public Text FinalText;
    public string[] Location1 = new string[6];
    public string[] Location2 = new string[6];
    public string[] Location3 = new string[6];
    public string[] Location4 = new string[6];
    public string[] Location5 = new string[6];
    public string[] Type1 = new string[6];
    public string[] Type2 = new string[6];
    public string[] Type3 = new string[6];
    public string[] Name1 = new string[6];
    public string[] Name2 = new string[6];
    public string[] Name3 = new string[6];
    public string[] Name4 = new string[6];
    public string[] Name5 = new string[6];
    public string[] Object1 = new string[6];
    public string[] Object2 = new string[6];
    public string[] Object3 = new string[6];
    // Start is called before the first frame update
    void Start()
    {
        FirstWidnowEndPosition = new Vector3(StartMenu.transform.localPosition.x - move, 0, 0);
        //ìåñòà
        foreach (string loc in Locations)
        {
            Locations_dropDown.options.Add(new Dropdown.OptionData(loc));
        }
        //òèïû ïàðòèé
        foreach (string type in WorldTypes)
        {
            WorldType_dropDown.options.Add(new Dropdown.OptionData(type));
        }
        //íåèãðîâûå ïåðñîíàæè
        foreach (string Character in UnplayableCharacters_List)
        {
            var a = Instantiate(example, Content_UnplayableCharacters.transform);
            a.transform.GetChild(1).GetComponent<Text>().text = Character;
            /*a.transform.GetChild(1).GetComponent<Text>().verticalOverflow = VerticalWrapMode.Overflow;
            a.transform.GetChild(1).GetComponent<Text>().fontSize = 10;*/
        }
        //êëþ÷åâûå îáúåêòû
        foreach (string mainObject in MainObjects_List)
        {
            var a = Instantiate(example, Content_MainObjects.transform);
            a.transform.GetChild(1).GetComponent<Text>().text = mainObject;
        }

    }
    //Êíîïêà íà÷àòü
    public void FirstNext()
    {
        Page = Page + 1;
        //StartMenu_move = true;
        //StartMenu.transform.localPosition = new Vector3(StartMenu.transform.localPosition.x - move, 0, 0);
        StartMenu.GetComponent<Animator>().SetInteger("Num", Page);
    }
    public void Choselocation()
    {
       // Location_move = true;
        StartMenu.transform.localPosition = new Vector3(StartMenu.transform.localPosition.x - move, 0, 0);

    }
    public void WorldType()
    {
        //Location_move = true;
        StartMenu.transform.localPosition = new Vector3(StartMenu.transform.localPosition.x - move, 0, 0);

    }
    
    public void UnplayableCharacters()
    {
        //Location_move = true;
        StartMenu.transform.localPosition = new Vector3(StartMenu.transform.localPosition.x - move, 0, 0);

    }

    public void MainObjects()
    {
        //Location_move = true;
        StartMenu.transform.localPosition = new Vector3(StartMenu.transform.localPosition.x - move, 0, 0);


        //âûâîä ïðîìåæóòî÷íûõ ðåçóëüòàòîâ
        //ëîêàöèÿ
        BeforeVerdict.text = Locations_dropDown.options[Locations_dropDown.value].text;
        // Debug.Log(Locations_dropDown.options[Locations_dropDown.value].text);
        //ñåòòèíã
        BeforeVerdict.text = BeforeVerdict.text + "\n" + WorldType_dropDown.options[WorldType_dropDown.value].text;
        //Debug.Log(WorldType_dropDown.options[WorldType_dropDown.value].text);

        //íåèãðîâûå ïåðñîíàæè
        for (int i = 0; i < Content_UnplayableCharacters.transform.childCount; i++)
        {
            if (Content_UnplayableCharacters.transform.GetChild(i).GetComponent<Toggle>().isOn)
            {
                BeforeVerdict.text = BeforeVerdict.text + "\n" + Content_UnplayableCharacters.transform.GetChild(i).GetChild(1).GetComponent<Text>().text;
                // Debug.Log(Content_UnplayableCharacters.transform.GetChild(i).GetChild(1).GetComponent<Text>().text); 
            }

        }

        //êëþ÷åâûå îáúåêòû
        for (int i = 0; i < Content_MainObjects.transform.childCount; i++)
        {
            if (Content_MainObjects.transform.GetChild(i).GetComponent<Toggle>().isOn)
            {
                BeforeVerdict.text = BeforeVerdict.text + "\n" + Content_MainObjects.transform.GetChild(i).GetChild(1).GetComponent<Text>().text;
                //Debug.Log(Content_MainObjects.transform.GetChild(i).GetChild(1).GetComponent<Text>().text); 
            }

        }
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void GameRules()
    {
       
        Debug.Log(Rule);
    }
    public void allBack()
    {
        Page = 1;

        //FirstWidnowEndPosition = new Vector3(0, 0, 0);
        StartMenu.GetComponent<Animator>().SetInteger("Num", Page);
    }
    public void Back()
    {
        Page = Page - 1;
        //StartMenu.transform.localPosition = new Vector3(StartMenu.transform.localPosition.x + move, 0, 0);
        StartMenu.GetComponent<Animator>().SetInteger("Num", Page);
    }
    public void Finale()
    {
        List<string> Key_fitchList = new List<string>();
        List<string> UnplayableCharactersList = new List<string>();
        for (int i = 0; i < Content_UnplayableCharacters.transform.childCount; i++)
        {
            if (Content_UnplayableCharacters.transform.GetChild(i).GetComponent<Toggle>().isOn)
            {
                UnplayableCharactersList.Add(Content_UnplayableCharacters.transform.GetChild(i).GetChild(1).GetComponent<Text>().text);
                //BeforeVerdict.text = BeforeVerdict.text + "\n" + Content_UnplayableCharacters.transform.GetChild(i).GetChild(1).GetComponent<Text>().text;
                // Debug.Log(Content_UnplayableCharacters.transform.GetChild(i).GetChild(1).GetComponent<Text>().text); 
            }

        }

        //ключи
        for (int i = 0; i < Content_MainObjects.transform.childCount; i++)
        {
            if (Content_MainObjects.transform.GetChild(i).GetComponent<Toggle>().isOn)
            {
                Key_fitchList.Add(Content_UnplayableCharacters.transform.GetChild(i).GetChild(1).GetComponent<Text>().text);
                //BeforeVerdict.text = BeforeVerdict.text + "\n" + Content_MainObjects.transform.GetChild(i).GetChild(1).GetComponent<Text>().text;
                //Debug.Log(Content_MainObjects.transform.GetChild(i).GetChild(1).GetComponent<Text>().text); 
            }

        }
        Page = 7;
        string end = "";
        StartMenu.GetComponent<Animator>().SetInteger("Num", Page);
        // 0 0
        if (Locations_dropDown.value == 0 && WorldType_dropDown.value == 0)
        { 
        end=end+ "Героям нужно будет пройти через опасное подземелье, наполненное врагами и сокровищами";
        if(Key_fitchList.Contains("Артефакт, дарующий бессмертие"))
            {
                end = end + ", например, в одной из особо охраняемых пещер находится артефакт, дарующий бессмертие – главная цель";
            }
        if (UnplayableCharactersList.Contains("Большой и очень голодный дракон"))
            {
                end = end + ", в конце их встретит большой и очень голодный дракон, так что надо подготовиться";
            }

            end = end + ". В некоторых залах не обязательно сражаться: подземный мир наполнен ловушками, который можно использовать и себе во благо, если найти подходящий способ";
            if (UnplayableCharactersList.Contains("Король-Лич"))
            {
                end = end + ", а с Королём-Личом и не нужно драться вовсе: он задаёт вопросы, за ответы на которые награждает сильными предметами";
            }
            end = end + "Для каждого из персонажей игроков в сокровищницах найдётся что-то своё";
            if (Key_fitchList.Contains("Проклятый кинжал"))
            {
                end = end + "(Любителям проходить партии Плутом особенно понравится наш проклятый кинжал, который идеален для внезапных атак)";
            }
            end = end + " В обширной локации ведущему будет легко расположить секретные комнаты и загадки";
            if (UnplayableCharactersList.Contains("Кружка, которая обрела сознание"))
            {
                end = end + ", наградой за которые могут быть необычные вещи или существа, вроде кружки, что обрела сознание";
            }
            end = end + " А ещё здесь подойдут практически любые декорации";
            if (UnplayableCharactersList.Contains("Яблоко"))
            {
                end = end + " - от бочек с яблоками, чтобы герои могли подкрепиться, до огромных грибов";
            }
            end = end + ".";
        }

        // 0 1
        if (Locations_dropDown.value == 0 && WorldType_dropDown.value == 1)
        {
            end = end + "Герои живут в огромном мире, полностью находящемся под землёй – любителям играть за дроу такое точно понравится! Здесь можно делать всё, что захотят игроки, ";
            if (UnplayableCharactersList.Contains("Яблоко"))
            {
                end = end + "хоть выводить подземные сорта волшебных яблок,";
            }
            end = end + "главное не позволяйте им разбредаться по пещерам слишком сильно, в команде всегда интереснее ";
            if (UnplayableCharactersList.Contains("Король-Лич"))
            {
                end = end + "(а ещё герой-одиночка вряд ли одержит победу в поединке с всесильным Королём-Личом)";
            }

            end = end + ". Мир под землёй таит в себе много интересного";
            
            if (Key_fitchList.Contains("Проклятый кинжал"))
            {
                end = end + "например, гробницы, где захоронены все владельцы проклятого кинжала";
            }

            end = end + "Заскучать любителям сражений не позволят интересные противники";

            if (UnplayableCharactersList.Contains("Большой и очень голодный дракон"))
            {
                end = end + ", есть целый культ, поклоняющийся большому и злому дракону";
            }

            if (Key_fitchList.Contains("Артефакт, дарующий бессмертие"))
            {
                end = end + ", а если победить всех, то в качестве главного приза игроки получат артефакт, дарующий бессмертие";
            }

            end = end + " . Ведущему, конечно, будет довольно сложно организовать настолько массовое приключение, но если всё получится, то партия будет не только долгой, но и захватывающей на протяжении всего игрового процесса. ";
            if (UnplayableCharactersList.Contains("Кружка, которая обрела сознание"))
            {
                end = end + " Если те, с кем вы играете, хотят модифицировать ваш мир перед партией, то прислушайтесь к ним, быть может, вместе игроки придумают что-то смешное, вроде пещеры, населённой кружками, которые обрели сознание";
            }
            end = end + ".";
        }

        // 0 2
        if (Locations_dropDown.value == 0 && WorldType_dropDown.value == 2)
        {
            end = end + " Эта партия не рассчитана на долгую игру, здесь игроки смогут померяться своей удачей и умением планировать действия наперёд. По сюжету герои попадают на подземную арену";
            
            if (UnplayableCharactersList.Contains("Король-Лич"))
            {
                end = end + ", построенную самим Королём-Личом ";
            }

            end = end + "и должны сразиться друг с другом за ценнейшие сокровища";

            if (Key_fitchList.Contains("Артефакт, дарующий бессмертие"))
            {
                end = end + "среди которых есть артефакт, дарующий бессмертие";
            }

            end = end + ". Изначально персонажи разделены препятствиями, но чем ближе они будут подходить к центру ";

            if (Key_fitchList.Contains("Проклятый кинжал"))
            {
                end = end + ", где располагается проклятый кинжал – сильное оружие, ради которого им стоит туда поспешить";
            }

            end = end + ", тем легче им будет напасть друг на друга.";

            if (Key_fitchList.Contains("Яблоко"))
            {
                end = end + "Если хотите дать второй шанс, чтобы бой меньше зависел от везения, можете раскидать по арене лечащие магические яблоки.";
            }

            if (UnplayableCharactersList.Contains("Большой и очень голодный дракон"))
            {
                end = end + "Хоть и главное здесь – сражения между игроками, но можно разбавить процесс каким-нибудь сильным противником в центре – хорошо подойдёт большой и голодный дракон.";
            }

            end = end + "  Не каждому понравится такой вариант игры – особенно любителям больших и проработанных миров. Но это неплохой способ расслабиться между сложными и проработанными играми. При желании можете сделать несколько раундов, между которыми павших героев ждёт воскрешение и отдых в маленькой промежуточной локации.";
            if (UnplayableCharactersList.Contains("Кружка, которая обрела сознание"))
            {
                end = end + "Если вы нацелены больше на аркадное и забавное сражение, нежели на серьёзное, то такое место можно заселить любыми странными персонажами, которые смогут разрядить обстановку – как насчёт кружки, которая обрела сознание?";
            }
            end = end + ".";
        }


        // 1 0
        if (Locations_dropDown.value == 1 && WorldType_dropDown.value == 0)
        {
            end = end + "Команде героев предстоит исследовать руины некогда процветающего города. ";

            if (UnplayableCharactersList.Contains("Кружка, которая обрела сознание"))
            {
                end = end + "Древняя магия, что его разрушила, как оказалось, имела побочный эффект – предметы стали обретать свою волю и сознание, и на данный момент их главарём является ожившая кружка.";
            }

            end = end + "Тому, кто будет вести игру, довольно просто будет адаптировать такую локацию под любую историю";

            if (UnplayableCharactersList.Contains("Большой и очень голодный дракон"))
            {
                end = end + "(к примеру, если город уничтожил большой и очень голодный дракон, то он может быть финальным боссом)";
            }

            end = end + ". В зависимости от того, какой город был разрушен, там может оказаться что угодно: спрятанное от пожара наследство богатого торговца, чей-то замок, теперь населённый нечистью";

            if (UnplayableCharactersList.Contains("Король-Лич"))
            {
                end = end + " Короля-Лича";
            }

            end = end + ", источник заражения, от которого уехали все жители";

            if (Key_fitchList.Contains("Проклятый кинжал"))
            {
                end = end + ", проклятый кинжал, забытый своим владельцем,";
            }

            if (Key_fitchList.Contains("Артефакт, дарующий бессмертие"))
            {
                end = end + " или артефакт, дарующий бессмертие, находящийся под городом";
            }

            end = end + "– этот сценарий очень хорошо подстраивается под ваши нужды. ";
            if (Key_fitchList.Contains("Яблоко"))
            {
                end = end + "Для создания более мрачной атмосферы рекомендуется добавить что-то в вашу историю, что было прекрасно раньше, но испорчено или разрушено в наши дни, например, большая высохшая яблоня, на которой осталось только одно яблоко.";
            }
            end = end + ".";
        }


        // 1 1
        if (Locations_dropDown.value == 1 && WorldType_dropDown.value == 1)
        {
            end = end + " Этот сценарий позволяет игрокам исследовать руины заброшенного города," +
                " здесь можно идти в любом направлении и выполнять любой из нескольких возможных квестов – на поселение нападают враги со всех сторон," +
                " чтобы захватить освободившуюся территорию, среди них могут быть те фракции, что вам больше нравятся:";

            if (UnplayableCharactersList.Contains("Большой и очень голодный дракон"))
            {
                end = end + "стая рептилий, возглавляемая большим и очень голодным драконом,";
            }

            //end = end + "Тому, кто будет вести игру, довольно просто будет адаптировать такую локацию под любую историю";


            if (UnplayableCharactersList.Contains("Король-Лич"))
            {
                end = end + "армия мёртвых вместе с Королём-Личом,";
            }

            end = end + "шайка воров, которая желает разграбить то, что осталось от развалин," +
                " гильдия ассасинов, ищущая место для своей новой базы или королевский легион, который хочет отстроить город заново ";

            if (UnplayableCharactersList.Contains("Кружка, которая обрела сознание"))
            {
                end = end + "(можете сделать события смешнее, добавив армию оживших кружек)";
            }

            end = end + ". Цели героев могут быть разными, быть может они хотят забрать какие-нибудь ценности ";

            if (Key_fitchList.Contains("Проклятый кинжал"))
            {
                end = end + ",вроде проклятого кинжала, принадлежащего раньше главе города";
            }
            end = end + ", может здесь раньше была их лаборатория";
            if (Key_fitchList.Contains("Артефакт, дарующий бессмертие"))
            {
                end = end + ", где они хотели воссоздать артефакт, дарующий бессмертие,";
            }

            end = end + " или база";
            if (Key_fitchList.Contains("Яблоко"))
            {
                end = end + ", где они просто выращивали яблоки на продажу и никого не трогали";
            }
            end = end + ". Этот, с одной стороны открытый для исследования сценарий, заставит игроков торопиться и породит немало крутых и напряжённых ситуаций.";
        }

        // 1 2

        if (Locations_dropDown.value == 1 && WorldType_dropDown.value == 2)
        {
            end = end + "По сюжету, персонаж какого-то из игроков украл что-то у группы остальных, и теперь они хотят отомстить." +
                " Пытаясь оторваться от преследователей, вор забредает в заброшенный город. У этого сценария есть несколько сложностей," +
                " связанных с реализацией. Во-первых, сложно будет одновременно описывать место," +
                " где находится преследуемый и делать то же самое для его преследователей. Чтобы избежать этого, старайтесь почаще держать их в одном месте по каким-то причинам";

            if (UnplayableCharactersList.Contains("Король-Лич"))
            {
                end = end + "(город может быть заброшен не просто так, возможно большая часть территории контролируется армией Короля-Лича," +
                    " и безопасных мест для игроков останется не так уж и много)";
            }

            end = end + ". Во-вторых, преследуемый должен иметь шансы в противостоянии с целой командой других героев. ";


            if (Key_fitchList.Contains("Артефакт, дарующий бессмертие"))
            {
                end = end + "Можно дать ему цель - найти в городе артефакт, дарующий бессмертие, чтобы победить своих врагов.";
            }

            end = end + "Не забудьте расположить в локации интересных врагов";

            if (UnplayableCharactersList.Contains("Большой и очень голодный дракон"))
            {
                end = end + ", вроде большого и очень голодного дракона";
            }

            end = end + ", расходники";

            if (Key_fitchList.Contains("Яблоко"))
            {
                end = end + "(волшебные яблоки для восстановления здоровья)";
            }
            end = end + "и несколько сильных предметов для игрока-вора";
            if (Key_fitchList.Contains("Проклятый кинжал"))
            {
                end = end + "(если он играет плутом, то проклятый кинжал – отличное решение)";
            }

            end = end + ", тогда в случае чего он сможет дать отпор.";
            if (UnplayableCharactersList.Contains("Кружка, которая обрела сознание"))
            {
                end = end + "Если вам покажется, что этого мало, дайте вору какого-нибудь волшебного советчика, через которого вы сможете ему помочь." +
                    " Что-то странное и одновременно с этим запоминающееся, вроде говорящей кружки, подойдёт";
            }
        }

        // 2 0
        if (Locations_dropDown.value == 2 && WorldType_dropDown.value == 0)
        {
            end = end + "Эта история происходит в вещем сне одного из влиятельных королей";

            if (Key_fitchList.Contains("Артефакт, дарующий бессмертие"))
            {
                end = end + ", он был навечно усыплён за счёт сбоя артефакта, который дал ему бессмертие";
            }

            end = end + ". Задача героев – предупредить его о грядущей беде: все противники – гоблины, орки, ";


            if (UnplayableCharactersList.Contains("Король-Лич"))
            {
                end = end + "скелеты по главе с Королём-Личом, ";
            }

            end = end + "Не забудьте расположить в локации интересных врагов";

            if (UnplayableCharactersList.Contains("Большой и очень голодный дракон"))
            {
                end = end + "дракониды под началом большого и очень голодного дракона,";
            }

            // end = end + ", расходники";

            if (UnplayableCharactersList.Contains("Кружка, которая обрела сознание"))
            {
                end = end + "маги, один из которых переселил свой разум в кружку";
            }
            end = end + "и элементали объединились против его королевства. Так как это сон, ведущий может" +
                " придумать любое интересное задание, не опираясь на реализм и создать действительно зрелищные сцены";
            if (Key_fitchList.Contains("Яблоко"))
            {
                end = end + "что-то вроде моря яблок или любого другого иррационального пейзажа";
            }

            end = end + ". Игрокам также понадобится найти способ разбудить правителя ";
            if (Key_fitchList.Contains("Проклятый кинжал"))
            {
                end = end + "одним из решений может быть превращение сна в кошмар при помощи" +
                    " силы проклятого кинжала";
            }
            end = end + ".";
        }



        // 2 1
        if (Locations_dropDown.value == 2 && WorldType_dropDown.value == 1)
        {
            end = end + " Эта история происходит во сне одного из обычных детей, живущих" +
                " в фэнтезийном мире. Персонажи игроков ему приснились, и от их действий будет" +
                " зависеть то, кем вырастет этот ребёнок." +
                " Они должны путешествовать по сну и находить способы влиять на него.";

            if (UnplayableCharactersList.Contains("Кружка, которая обрела сознание"))
            {
                end = end + "Пробудить в его сознании странные образы," +
                    " например, говорящих предметов?";
            }

            //end = end + ". Задача героев – предупредить его о грядущей беде: все противники – гоблины, орки, ";


            if (UnplayableCharactersList.Contains("Большой и очень голодный дракон"))
            {
                end = end + "[Подвергнуть его разум страху от лицезрения страшных драконов?";
            }

            //end = end + "Не забудьте расположить в локации интересных врагов";

            if (UnplayableCharactersList.Contains("Король-Лич"))
            {
                end = end + "Показать ему самого Короля-Лича, чтобы он узнал," +
                    " насколько может быть опасно зло?";
            }

            // end = end + ", расходники";

            if (Key_fitchList.Contains("Яблоко"))
            {
                end = end + "Продемонстрировать бесконечные поля плодоносящих деревьев?";
            }

            if (Key_fitchList.Contains("Проклятый кинжал"))
            {
                end = end + "Использовать проклятое оружие?";
            }

            if (Key_fitchList.Contains("Артефакт, дарующий бессмертие"))
            {
                end = end + "Рассказать ему про силу и опасность артефактов?";
            }
            end = end + "Только игрокам решать, что случится," +
                " а потому ведущий должен как следует подготовиться к такой нестандартной партии.";
        }

        if (Locations_dropDown.value == 2 && WorldType_dropDown.value == 2)
        {

            end = "Главные герои – маги снов, которые забрались в разум человека и хотят его захватить." +
                    " (Для идеального отыгрыша рекомендуется взять персонажей, которые хорошо умеют колдовать, но это не обязательно," +
                    " поскольку из-за своих сил персонажи могут стать кем угодно, поэтому генерация сценария здесь может быть также чем угодно," +
                    " все элементы, предметы, персонажи и окружение могут присутствовать. Или не присутствовать. Решать только вам.)" +
                    " Этот сценарий пока находится на чисто концептуальном уровне, поскольку для такого нужно написать часть новых правил," +
                    " на что способен не каждый. Но идея показалась интересной";
        }
            FinalText.text = end;
        //локация
        /*BeforeVerdict.text = Locations_dropDown.options[Locations_dropDown.value].text;
        // Debug.Log(Locations_dropDown.options[Locations_dropDown.value].text);
        //сетинг
        BeforeVerdict.text = BeforeVerdict.text+"\n"+ WorldType_dropDown.options[WorldType_dropDown.value].text;
        //Debug.Log(WorldType_dropDown.options[WorldType_dropDown.value].text);

        //персы
     */

    }

    // Update is called once per frame
    void Update()
    {
       /* if (first_move)
        {
            MovebleObject.transform.localPosition = Vector3.Lerp(MovebleObject.transform.position, FirstWidnowEndPosition, Time.deltaTime);
        }*/
    }
}
