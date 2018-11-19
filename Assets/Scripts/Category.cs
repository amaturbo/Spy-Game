using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class Category : MonoBehaviour {

    List<string> names = new List<string>();
    public List<Sprite> HeroImages = new List<Sprite>();
    public List<Sprite> FoodImages = new List<Sprite>();
    public List<Sprite> ColorImages = new List<Sprite>();
    public Info info;
    public GameObject panel;

    // Use this for initialization
    void Start () {
        panel.SetActive(false);
    }

    public void SuperHero()
    {
        panel.SetActive(true);
        names.AddRange(new string[] {"Superman", "Batman", "Spider-man", "Thor", "Iron man", "Captain America", "Wonder Woman", "Flash", "Green Lantern", "Hulk", "Deadpool",
            "Poison Ivy", "Catwoman" , "Harley Quinn", "Aquaman", "Cyborg", "Venom", "Black Panther", "Black Widow", "Ant-Man", "Star Lord", "Hawkeye", "Scarlet Witch", "Vision"
        , "Doctor Strange", "Rocket Raccoon", "Groot", "Wolverine", "Quicksilver"});
        info.SetUp(names, HeroImages);
    }

    public void Food()
    {
        panel.SetActive(true);
        names.AddRange(new string[] {"Bacon", "Burger", "Chicken", "Eggs", "Lobster", "Pasta", "Pizza", "Shrimp", "Sushi"
        , "Apple", "Avocado", "Bagels", "Baguettes", "Banana", "Bell pepper", "Blackberry", "Blueberry", "Bread", "Broccoli",
            "Cabbage", "Cake", "Candy cane", "Caramel", "Carrot", "Caviar", "Cereal", "Cheese", "Chocolate", "Clam", "Coconut"
        , "Corndog", "Cotton candy", "Crackers", "Cranberry", "Croissant", "Cucumber", "Cupcake", "Doughnuts", "Dumplings",
            "Eggplant", "French fries", "Ginger", "Grape", "Grapefruit", "Hot dog", "Ice cream", "Kale", "Kebab", "Kiwi"
        , "Lasagna", "Lemon", "Lentil", "Lettuce", "Lime", "M&M's", "Mango", "Marshmallow", "Milk", "Mushrooms"
        , "Nectarine", "Octopus", "Onion", "Onion rings", "Orange", "Oyster", "Pancakes", "Papaya", "Peach", "Peanut"
        , "Peas", "Pie", "Pineapple", "Potato chips", "Potato", "Pumpkin", "Radish", "Ramen", "Raspberry", "Rice"
        , "Sandwich", "Sausages", "Soup", "Spinach", "Strawberry", "Stew", "Tomato", "Turnip", "Waffle", "Watermelon", "Yoghurt"});
        info.SetUp(names, FoodImages);
    }

    public void Color()
    {
        panel.SetActive(true);
        names.AddRange(new string[] {"Aqua", "Black", "Blue", "Gray", "Green", "Yellow", "Maroon", "Navy", "Purple", "Red", "Teal", "White"});
        info.SetUp(names, ColorImages);
    }
}
