// <snippet1>
using System;
using System.Collections;
using System.ComponentModel;

namespace ReadOnlyPropertyDescriptorTest;

// The SerializeReadOnlyPropertyDescriptor shows how to implement a 
// custom property descriptor. It provides a read-only wrapper 
// around the specified PropertyDescriptor. 
sealed class SerializeReadOnlyPropertyDescriptor : PropertyDescriptor
{
    readonly PropertyDescriptor _pd;

    public SerializeReadOnlyPropertyDescriptor(PropertyDescriptor pd)
        : base(pd) => _pd = pd;

    public override AttributeCollection Attributes => AppendAttributeCollection(
                _pd.Attributes,
                ReadOnlyAttribute.Yes);

    protected override void FillAttributes(IList attributeList) => attributeList.Add(ReadOnlyAttribute.Yes);

    public override Type ComponentType => _pd.ComponentType;

    // The type converter for this property.
    // A translator can overwrite with its own converter.
    public override TypeConverter Converter => _pd.Converter;

    // Returns the property editor 
    // A translator can overwrite with its own editor.
    public override object GetEditor(Type editorBaseType) => _pd.GetEditor(editorBaseType);

    // Specifies the property is read only.
    public override bool IsReadOnly => true;

    public override Type PropertyType => _pd.PropertyType;

    public override bool CanResetValue(object component) => _pd.CanResetValue(component);

    public override object GetValue(object component) => _pd.GetValue(component);

    public override void ResetValue(object component) => _pd.ResetValue(component);

    public override void SetValue(object component, object val) => _pd.SetValue(component, val);

    // Determines whether a value should be serialized.
    public override bool ShouldSerializeValue(object component)
    {
        bool result = _pd.ShouldSerializeValue(component);

        if (!result)
        {
            DefaultValueAttribute dva = (DefaultValueAttribute)_pd.Attributes[typeof(DefaultValueAttribute)];
            result = dva == null || !Equals(_pd.GetValue(component), dva.Value);
        }

        return result;
    }

    // The following Utility methods create a new AttributeCollection
    // by appending the specified attributes to an existing collection.
    public static AttributeCollection AppendAttributeCollection(
        AttributeCollection existing,
        params Attribute[] newAttrs) => new(AppendAttributes(existing, newAttrs));

    public static Attribute[] AppendAttributes(
        AttributeCollection existing,
        params Attribute[] newAttrs)
    {
        if (existing == null)
        {
            throw new ArgumentNullException(nameof(existing));
        }

        newAttrs ??= [];

        Attribute[] attributes;

        Attribute[] newArray = new Attribute[existing.Count + newAttrs.Length];
        int actualCount = existing.Count;
        existing.CopyTo(newArray, 0);

        for (int idx = 0; idx < newAttrs.Length; idx++)
        {
            if (newAttrs[idx] == null)
            {
                throw new ArgumentNullException(nameof(newAttrs));
            }

            // Check if this attribute is already in the existing
            // array.  If it is, replace it.
            bool match = false;
            for (int existingIdx = 0; existingIdx < existing.Count; existingIdx++)
            {
                if (newArray[existingIdx].TypeId.Equals(newAttrs[idx].TypeId))
                {
                    match = true;
                    newArray[existingIdx] = newAttrs[idx];
                    break;
                }
            }

            if (!match)
            {
                newArray[actualCount++] = newAttrs[idx];
            }
        }

        // If some attributes were collapsed, create a new array.
        if (actualCount < newArray.Length)
        {
            attributes = new Attribute[actualCount];
            Array.Copy(newArray, 0, attributes, 0, actualCount);
        }
        else
        {
            attributes = newArray;
        }

        return attributes;
    }
}
// </snippet1>
