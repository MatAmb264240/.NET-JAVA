package org.example;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Random;

public class Problem
{
    private static int N;
    private static int seed;
    private static Random random;

    Problem(int n, int seed)
    {
        this.N = n;
        this.seed = seed;
        this.random = new Random(this.seed);
    }
    static public Result solve(ArrayList<Przedmiot> przedmioty, int capacity)
    {
        Collections.sort(przedmioty, (a, b) -> Double.compare((double) b.value / b.weight,
                (double) a.value / a.weight));

        ArrayList<Integer> selectedItems = new ArrayList<>();
        int totalValue = 0;
        int totalWeight = 0;

        for (Przedmiot przedmiot : przedmioty) {
            if (totalWeight + przedmiot.weight <= capacity) {
                selectedItems.add(przedmiot.id);
                totalValue += przedmiot.value;
                totalWeight += przedmiot.weight;
            }
        }

        return new Result(selectedItems, totalValue, totalWeight);
    }

    public ArrayList<Przedmiot> generateItems(int n) {
        ArrayList<Przedmiot> przedmioty = new ArrayList<>();
        for (int i = 1; i <= n; i++) {
            int value = random.nextInt(10) + 1;
            int weight = random.nextInt(10) + 1;
            przedmioty.add(new Przedmiot(i, value, weight));
            System.out.println(przedmioty.get(i - 1).toString());
        }
        return przedmioty;
    }
}
