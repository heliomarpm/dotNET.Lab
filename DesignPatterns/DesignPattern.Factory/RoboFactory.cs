using System;

namespace DesignPattern.Factory
{

    public static class RoboFactory
    {

        public static RoboAbstract Criar(ERobos robo)
        {
            return Criar(robo.ToString());
        }

        public static RoboAbstract Criar(String robo)
        {
            switch (robo)
            {
                case "C6PO":
                    return new C6PO();

                case "Optimus_Prime":
                    return new Optimus_Prime();

                case "Bumblebee":
                    return new Bumblebee();

                default:
                    return null;
            }

        }

    }

}
