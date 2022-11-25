//=============================================================================
// Program's Item class
//=============================================================================

namespace Shop
{
    // TODO: Write a class called Item that contains 2 data members:
    //       A string called name and an int called cost.
    //       This class should have a default constructor that sets name to ""
    //       and cost to 0.
    //       It should also have an overloaded constructor that accepts 2
    //       parameters - a string and an int.
    internal class Item
    {
        private string name;
        private int cost;

        public Item()
        {
            this.name = "";
            this.cost = 0;
        }

        public Item(string name, int cost)
        {
            this.name = name;
            this.cost = cost;
        }
        //       Write getters/accessors for each data member. They should be called
        //       GetName and GetCost.
        public string GetName() => this.name;

        public int GetCost() => this.cost;
        //       Write setters/mutators for each data member. They should be called
        //       SetName and SetCost.
        public void SetName(string _name) => this.name = _name;

        public void SetCost(int _cost) => this.cost = _cost;
    }
