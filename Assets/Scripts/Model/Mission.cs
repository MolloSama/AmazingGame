using System.Collections;
using System.Collections.Generic;

public class Mission{

    public string SerialNumber { get; set; }

    public int CurrentIndex { get; set; }

    public string Title { get; set; }

    public List<string> Descriptions { get; set; }

    public Mission(string serialNumber, int currentIndex, string title, List<string> descriptions)
    {
        SerialNumber = serialNumber;
        CurrentIndex = currentIndex;
        Title = title;
        Descriptions = descriptions;
    }
}
