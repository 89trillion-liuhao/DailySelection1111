# DailySelection1111# 每日精选
## 整体框架
1、首先导入资源对象，调整相应的位置，属性等。  
2、编写脚本读取json，并且给相应的组件编写事件    
3、绑定脚本与游戏对象  
4、运行测试程序  
## 目录结构
Assets
>> Materials  
>> Prefabs 
>> Resources
>> resoures 
>> Scenes  
>> Scripts  
>> StreamingAssets  
## 界面结构拆分
### Hierarchy层
MainScenes 场景 
> Main Camera  
> Directional Light   
> AllCanvas  
>> Canvas  
>> IndexCanvas
>> 金币信息位置
>> TitleLables 2个(每日精选一个，士兵招募一个)  
>>  MainLable 2个
>>> DayCardsBgLable 每日精选1个
>>>> CardBackgroundLab 每日精选宝箱位3n个
>>>>> BuyButton 购买按钮
>>>>>> img 金币 对号  
>>>>>> Text 价格 已购买   
>>>>> img 宝箱图片  
>>>>> titleText 名称   
>>> SoldiersBgLable 士兵招募1个   
>>>> SoldBackgroundLab 士兵招募1个  
### Prefab 预制件
> 3个Prefab
>> 宝箱一个    
>> 按钮一个    
>> 飘动金币1个  
## 代码结构
> 3个脚本文件  
>> ChangeScene 主场景控制器  
>>> StartSceneView 场景初始化方法  
>>> SceneChangeView 场景切换方法  
>>> QuitSceneView 退出场景  
>> GameObjectEvent 游戏事件类  
>>> ButtonClick 按钮点击方法   
>>> AlreadyBuy 宝箱已购买方法    
>>> ReadyBuy 宝箱未购买方法  
## 流程图
![Image text](https://github.com/89trillion-liuhao/myTest/blob/main/1.png)
