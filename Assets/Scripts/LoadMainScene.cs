
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using UnityEngine.EventSystems;

public class LoadMainScene : MonoBehaviour
{
    // Start is called before the first frame update
    //用于读取文件
    public TextAsset simple;
    //声明GameObject存放路径对象
    public GameObject canvas;
    //声明Card信息数组 存放解析过后的json数据
    public ShowCardInfo[] showJson;

    public int x;//当前画布的x坐标轴

    public int y;//当前画布的y坐标轴
    //获取资源对象
    //public DefaultControls.Resources uiResources;
    void Start()
    {
        //根据tag获取父元素
        canvas = GameObject.FindWithTag("DailyTags");
        x = 30 ;
        y = 0;
        LoadSceneInfo();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //按钮点击⌚️
    public void OnClick()
    {
        
        //获取当前点击的对象
        var buttonSelf = EventSystem.current.currentSelectedGameObject;
        Transform cardImg = buttonSelf.GetComponentInParent<Transform>().parent;
        foreach (Transform child in cardImg)
        {

            string names = child.gameObject.name;
            if ( names== "BottomBtn" || names.Equals("BottomBtn") || names== "GemImgBtn" || names.Equals("GemImgBtn")||names== "IconImgBtn" || names.Equals("IconImgBtn"))
            {
                child.gameObject.SetActive(false);
            }
            else if (names == "OKImg" || names.Equals("OKImg"))
            {
                child.gameObject.SetActive(true);
            }
        }
    }

    void LoadSceneInfo()
    {
        
        
        // -----------------------------创建每日精选部分-----------------begin   
        int addY = -620;
        int addX = 330;
        //var tempJsons = JSON.Parse(simple.text);
        simple = Resources.Load("data") as TextAsset;
        JSONNode tempJsons = JSON.Parse(simple.text);
        
        //JSONNode tempJsons = JSONObject.Load(Application.streamingAssetsPath + "/data.json");
        int jsonCount= tempJsons["dailyProduct"].Count;
        
        //定义cha补足不满3的部分 start
        int cha = jsonCount % 3;
        if (cha != 0)
        {
            jsonCount += 3 - cha;
        }
        //end
        
        for (int i = 0; i < jsonCount; i++)
        {
            
            ShowCardInfo tempJson = new ShowCardInfo();
            //计算位置
            if (x > 1000 - 330 )
            {
                y += addY;
                x = 30;
            }
            else if (i != 0)
            {
                x += addX;
            }
            tempJson.postionX = x;
            tempJson.postionY = y;
            tempJson.productId = tempJsons["dailyProduct"][i]["productId"].AsInt;
            tempJson.type = tempJsons["dailyProduct"][i]["type"].AsInt;
            tempJson.subType= tempJsons["dailyProduct"][i]["subType"].AsInt;
            tempJson.num = tempJsons["dailyProduct"][i]["num"].AsInt;
            tempJson.costGold = tempJsons["dailyProduct"][i]["costGold"].AsInt;
            tempJson.isPurchased = tempJsons["dailyProduct"][i]["isPurchased"].AsInt;
            tempJson.costGem = tempJsons["dailyProduct"][i]["costGem"].AsInt;
            if (i == 0 )
            {
                int isGold = Random.Range(0, 1);//随机数
                if (isGold == 1)    //如果等于1
                {
                    tempJson.costGem = tempJson.costGold;
                    
                }

                tempJson.isGold = isGold;
            }
            else
            {
                tempJson.isGold = 1;
            }
            CreateCard(tempJson);
        }
        // -----------------------------创建每日精选部分-----------------end
        
        // -----------------------------创建士兵招募-----------------begin   
        y -= 380;
        CreateSoilderBanner(310,y);
        
        // -----------------------------创建士兵招募-----------------begin  
        y -= 500;
        CreateSoilderCard(-10,y);

    }
    
    /**
     * 创建每日精选部分
     */
    public void CreateCard(ShowCardInfo info)
    {
        
        GameObject cardImage = Instantiate(Resources.Load("CardImg")) as GameObject;
        cardImage.GetComponent<Transform>().SetParent(canvas.transform);
        cardImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(info.postionX,info.postionY);
        Transform transform = cardImage.GetComponentInChildren<Transform>();
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
            string name = child.gameObject.name;
            if (info.isPurchased == 1) //1显示已购买
            {
                if (name == "OKImg" || name.Equals("OKImg") || name == "CostText" || name.Equals("CostText")) 
                {
                    child.gameObject.SetActive(true);
                }
                else if (info.isGold != 1 && (name == "GemImg" || name.Equals("GemImg")))
                {
                    child.gameObject.SetActive(true);
                }
                else if (info.isGold == 1 && (name == "IconImg" || name.Equals("IconImg")))
                {

                            child.gameObject.SetActive(true);
      
                }
                else
                {
                    child.gameObject.SetActive(false);
                }

            }
            else if(info.isPurchased == -1) //-1显示未购买
            {
                
                if (name == "BottomBtn" || name.Equals("BottomBtn") )
                {
                    Button btn = (Button) child.GetComponent<Button>();
                    
                }
                else
                {
                    child.gameObject.SetActive(false);
                }

                if (name == "CostText" ||name.Equals("CostText") )
                {
                    Text text = child.transform.GetComponent<Text>();
                    text.text = info.costGold+"";
                }
                if (info.isGold == 1 && (name == "IconImg" || name.Equals("IconImg") || name == "IconImgBtn" || name.Equals("IconImgBtn") || name == "CostText") || name.Equals("CostText"))//金币
                {
                    child.gameObject.SetActive(true);
                    if (name == "CostText" || name.Equals("CostText"))
                    {
                        Text costGold = child.GetComponent<Text>();
                        costGold.text = info.costGold+"";
                    }
                    
                }
                else if (info.isGold != 1 && (name == "GemImg" || name.Equals("GemImg") || name == "GemImgBtn" || name.Equals("GemImgBtn") ))
                {
                    child.gameObject.SetActive(true);
                }
                
                
            }
            else if (info.type == 0 )//是否为空对象 0是空对象 空对象就未解锁
            {
                if (name == "CardContentimg" || name.Equals("CardContentimg") || name == "ImgTitle" || name.Equals("ImgTitle") ||name == "UnLock" || name.Equals("UnLock") )
                {
                    child.gameObject.SetActive(true);
                }
                else
                {
                    child.gameObject.SetActive(false);
                }
                //
                
            }

            if (name == "CardContentImg" || name.Equals("CardContentImg") || name == "ImageTitle" ||
                name.Equals("ImageTitle"))
            {
                child.gameObject.SetActive(true);
            }
            
            //Debug.Log(child.gameObject.name);
        }
        //cardImage.GetComponentInChildren()
            //.SetPositionAndRotation();
        // Debug.Log(info.ToString());
    }

    /**
     * 创建士兵banner
     */
    public void CreateSoilderBanner(int x,int y)
    {
        
        
        GameObject banner =  Instantiate(Resources.Load("SoilderBanner")) as GameObject;
        banner.GetComponent<Transform>().SetParent(canvas.transform);
        banner.GetComponent<RectTransform>().anchoredPosition = new Vector2(x,y);
    }

    /**
     * 创建士兵招募卡牌
     */
    public void CreateSoilderCard(int x,int y)
    {
        
        GameObject card =  Instantiate(Resources.Load("SoilderCard")) as GameObject;
        card.GetComponent<Transform>().SetParent(canvas.transform);
        card.GetComponent<RectTransform>().anchoredPosition = new Vector2(x,y);
    }
}
