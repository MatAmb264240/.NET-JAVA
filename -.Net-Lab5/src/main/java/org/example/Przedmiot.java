package org.example;

public class Przedmiot {
    public int id;
    public int value;
    public int weight;

    Przedmiot(int id, int value, int weight) {
        this.id = id;
        this.value = value;
        this.weight = weight;
    }
    @Override
    public String toString()
    {
        return ("ID: " + id + " Value: " + value + " Weight: " + weight);
    }
}
