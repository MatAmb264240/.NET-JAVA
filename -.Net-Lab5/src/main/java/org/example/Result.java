package org.example;
import java.lang.reflect.Array;
import java.util.ArrayList;
public class Result {

    public ArrayList <Integer> selectedItems;
    public int TotalValue;
    public int TotalWeight;

    public Result(ArrayList<Integer> selectedItems, int totalValue, int totalWeight)
    {
        this.selectedItems = selectedItems;
        this.TotalValue = totalValue;
        this.TotalWeight = totalWeight;
    }
    @Override
    public String toString()
    {
        return (selectedItems.toString() + "\t" + "Value: " + TotalValue + "\t" + "Weight:" + TotalWeight + "\n");
    }
}
