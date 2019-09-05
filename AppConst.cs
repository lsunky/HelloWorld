/// <summary>
/// Author      Liuxun
/// Date        2018/9/10 14:39:28
/// Description:AppConst  增加说明
/// </summary>

using System;
/// <summary>
/// AppConst
/// </summary>

public class AppConst
{
    public const string excelContent = "d:/test/excel/";
    public const string configRoot = "d:/test/config/";
    public const string classRoot = "d:/test/class/";
    public const string nameSpace = "AppConfig";
}

/// <summary>
/// 配置类型，
/// </summary>
public enum ConfigUseType
{
    /// <summary>
    /// 前后端都用
    /// </summary>
    All,
    /// <summary>
    /// 客户端用
    /// </summary>
    Client,

    /// <summary>
    /// 服务器用
    /// </summary>
    Server,

    /// <summary>
    /// 忽略项
    /// </summary>
    Ignore,
}

public enum FieldType
{
    FieldType_int,
    FieldType_string,
    FieldType_double,
    FieldType_bool
}

