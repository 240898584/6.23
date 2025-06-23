using UnityEngine;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class CSVToClassGenerator : MonoBehaviour
{
    // CSV 文件路径
    private string csvFilePath;

    // 生成 C# 类的方法
    public void GenerateClass()
    {
        if (string.IsNullOrEmpty(csvFilePath))
        {
            Debug.LogError("请先选择 CSV 文件！");
            return;
        }

        // 读取 CSV 文件
        string[] lines = File.ReadAllLines(csvFilePath);
        if (lines.Length == 0)
        {
            Debug.LogError("CSV 文件为空！");
            return;
        }

        // 获取表头
        string[] headers = lines[0].Split(',');

        // 生成 C# 类代码
        StringBuilder classCode = new StringBuilder();
        classCode.AppendLine("using System;");
        classCode.AppendLine("");
        classCode.AppendLine("public class CSVData");
        classCode.AppendLine("{");

        foreach (string header in headers)
        {
            string propertyName = MakeValidPropertyName(header.Trim());
            classCode.AppendLine($"    public string {propertyName} {{ get; set; }}");
        }

        classCode.AppendLine("}");

        // 保存生成的类到文件
        string outputFilePath = Path.Combine(Application.dataPath, "GeneratedCSVData.cs");
        File.WriteAllText(outputFilePath, classCode.ToString());

        Debug.Log("C# 类已生成：" + outputFilePath);
    }

    // 用于记录已生成的属性名
    private HashSet<string> usedPropertyNames = new HashSet<string>();

    // 确保属性名是有效的 C# 标识符
    private string MakeValidPropertyName(string input)
    {
        // 移除无效字符
        string validName = System.Text.RegularExpressions.Regex.Replace(input, "[^a-zA-Z0-9_]", "");

        // 如果字符串为空，生成一个默认名称
        if (string.IsNullOrEmpty(validName))
        {
            validName = "Property";
        }

        // 如果以数字开头，添加前缀
        if (char.IsDigit(validName[0]))
        {
            validName = "_" + validName;
        }

        // 首字母大写
        validName = char.ToUpper(validName[0]) + validName.Substring(1);

        // 处理重复的属性名
        string originalName = validName;
        int counter = 1;
        while (usedPropertyNames.Contains(validName))
        {
            validName = originalName + counter;
            counter++;
        }

        usedPropertyNames.Add(validName);
        return validName;
    }

    // 选择 CSV 文件的方法（需要配合 UI 按钮使用）
    public void SelectCSVFile()
    {
        // 这里可以使用 Unity 的文件选择器插件，例如 StandaloneFileBrowser
        // 为了简化示例，这里手动设置文件路径
        csvFilePath = "d:/专高五/月考1/Assets/Resources/rune_config.csv";
    }
}