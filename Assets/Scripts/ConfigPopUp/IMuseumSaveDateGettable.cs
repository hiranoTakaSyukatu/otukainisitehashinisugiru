using System.Collections.Generic;
using TouchObjectType = Signal.C_TouchObjectType.TouchObjectType;

public interface IMuseumSaveDateGettable
{
    Dictionary<TouchObjectType, bool> GetMuseumDate();
}