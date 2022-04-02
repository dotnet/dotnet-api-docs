using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;

string xslMarkup = @"<?xml version='1.0'?>  
<xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='1.0'>  
    <xsl:template match='/Parent'>  
        <Root>  
            <C1><xsl:value-of select='Child1'/></C1>  
            <C2><xsl:value-of select='Child2'/></C2>  
        </Root>  
    </xsl:template>  
</xsl:stylesheet>";

XDocument xmlTree = new(
    new XElement("Parent",
        new XElement("Child1", "Child1 data"),
        new XElement("Child2", "Child2 data")
    )
);

XDocument newTree = new();
using (XmlWriter writer = newTree.CreateWriter())
{
    // Load the style sheet.  
    XslCompiledTransform xslt = new();
    xslt.Load(XmlReader.Create(new StringReader(xslMarkup)));

    // Execute the transform and output the results to a writer.  
    xslt.Transform(xmlTree.CreateNavigator(), writer);
}

Console.WriteLine(newTree);
