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
>> ChangeScene 切换场景类  
>>> InMainScene 进入主场景 
>>> ExitMainScene 退出主场景  
>>> FloatGold 金币生成动画  
>>> OnClick 购买按钮点击方法   
>>> createFloat 生成动画对象  
>> LoadMainScene 加载主场景页面
>>> OnClick 每日精选购买方法
>>> LoadSceneInfo 解析json并实例化为实体类
>>> CreateSoilderBanner 创建士兵页面 
>>> CreateSoilderCard 创建士兵招募页面  
>>> CreateCard 创建每日精选 
>> SimpleJSON 解析json格式类。
>> ShowCardInfo 展示信息实体类
## 流程图
![Image text](https://github.com/89trillion-liuhao/myTest/blob/main/1.png)
