package org.example;
import java.util.Scanner;
import java.util.ArrayList;
//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
            System.out.printf("Enter the number of items:");

            Scanner keyboard = new Scanner(System.in);
            int items = keyboard.nextInt();

            System.out.printf("Enter the seed:");
            int seed = keyboard.nextInt();

            System.out.printf("Enter the capacity:");
            int capacity = keyboard.nextInt();

            Problem problem = new Problem(items, seed);

            ArrayList<Przedmiot> przedmioty = problem.generateItems(items);
            Result result = problem.solve(przedmioty, capacity);

            System.out.println("Solution");
            System.out.println(result);
        }
}