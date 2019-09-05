# 930版本需求
## 武术会桑园  

1. 直接用条件包类型    
2. 标记所在目标死亡
3. 持续施法类型的倒计时条实现    有多个角色持续施法怎么办？

## 武术会藏马

1. 实现召唤执行
2. 生成召唤物，位置指定为敌方半场每个空格
3. 召唤物出现后经过一小段延迟后执行一个效果，这个效果是带条件判断的“立刻执行某技能”。而这个条件判断是指监听当有敌人进入施法者（即召唤物本身）所处格子时，条件成立（条件包类型302）,
4. 新增效果：指定效果组立刻结算剩余总伤害（伤害性质保持不变），并清除该效果。这个只适用于有持续时间和间隔时间的92类型效果。在这个效果里需要先利用条件类型103判断目标身上有没有指定效果组，然后在效果持续时间内监听。

## 武术会飞影

1. 效果94立刻调用技能功能拓展，新增参数控制是否要在当前技能施放完之后再调用。若填了是，则在再次施放之前该施法者其他手牌禁用。

## 死死若丸

1. 考虑新增一种伤害类型：无类型，用于分发其他伤害执行，例如死死若丸的必杀技，是对随机格子内的敌人造成的伤害。

## 鸦

1. .蓄力施法类型的实现。考虑用持续施法兼容。
2. 新增条件包类型：判断所处动作（例如倒地，这个动作在击飞击倒之后都有）。

## 牙野

1. 新增条件类型：当目标从当前所处负面状态A变成负面状态B时。

## 福袋

1. 服务器给福袋随机，服务器在跑战斗的时候把结果拿到
