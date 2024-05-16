package org.example;

import org.junit.jupiter.api.Test;

import java.util.ArrayList;

import static org.junit.jupiter.api.Assertions.*;
class ProblemTest {
@Test
    public void one_element_test()
    {

        ArrayList<Przedmiot> przedmioty  = new ArrayList<Przedmiot>();
        przedmioty.add(new Przedmiot (0, 5, 5));
        przedmioty.add(new Przedmiot (0, 3, 5));

        Result result = Problem.solve(przedmioty, 10);

        assertEquals(2, result.selectedItems.size());
    }

    @Test
    public void no_elements_test()
    {

        ArrayList<Przedmiot> przedmioty  = new ArrayList<Przedmiot>();
        przedmioty.add(new Przedmiot (0, 1, 20));
        przedmioty.add(new Przedmiot (0, 1, 20));

        Result result = Problem.solve(przedmioty, 10);

        assertEquals(0, result.selectedItems.size());
    }
    @Test
    public void fit_in_range()
    {
        Problem problem = new Problem(100, 10);
        ArrayList<Przedmiot> przedmioty  = problem.generateItems(100);

        for(int i = 0; i < przedmioty.size(); i++)
        {
            assertFalse(przedmioty.get(i).weight > 10  || przedmioty.get(i).weight <= 0 );
            assertFalse(przedmioty.get(i).value > 10  || przedmioty.get(i).value <= 0 );
        }
    }
    @Test
    public void check_correctness() {
        // Utwórz listę przedmiotów
        ArrayList<Przedmiot> przedmioty = new ArrayList<>();
        przedmioty.add(new Przedmiot(1, 5, 5));
        przedmioty.add(new Przedmiot(2, 3, 4));
        przedmioty.add(new Przedmiot(3, 2, 3));

        // Oblicz rozwiązanie
        Result result = Problem.solve(przedmioty, 10);

        // Oczekiwane wyniki
        int expectedTotalValue = 5 + 3;
        int expectedTotalWeight = 5 + 4;

        // Porównaj wyniki
        assertEquals(expectedTotalValue, result.TotalValue);
        assertEquals(expectedTotalWeight, result.TotalWeight);
    }


}