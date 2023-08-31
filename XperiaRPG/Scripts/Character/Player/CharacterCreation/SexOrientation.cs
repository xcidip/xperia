using System.Collections.Generic;
using XperiaRPG.Scripts.Character.Attributes;

namespace XperiaRPG.Scripts.Character.Player.CharacterCreation
{
    public class Sexuality : PlayerSetting
    {
        public Sexuality(string name, string description, AttBonus attBonus) 
            :base(name)
        {
            Description = description;
            AttBonus = attBonus;
        }
    }
    public class SexualityList : ChoiceList
    {
        public SexualityList()
        {

            List = new List<PlayerSetting>
            {
                new Sexuality("Heterosexual", "\n\tThy natural inclination of affection and union betwixt man and woman," +
                                              "\n\tas portrayed in the sacred scriptures with the story of Adam and Eve.", 
                    new AttBonus("Strength",2, "points")),
                new Sexuality("Homosexual", "\n\tThe affection and attraction found between individuals of the same gender," +
                                            "\n\twhich has been a subject of varied interpretations in the ancient texts.", 
                    new AttBonus("Seduction",30, "percent")),
                new Sexuality("Bisexual", "\n\tThe inclinations of the heart and affection that may extend to both genders," +
                                          "\n\talthough not expressly mentioned in the holy writings.", 
                    new AttBonus("Stamina",3, "points")),
                new Sexuality("Celibacy", "\n\tThe chosen path of abstinence from carnal desires, akin to the devoted life" +
                                          "\n\tled by certain revered biblical figures like Paul," +
                                          "\n\twho advocated for a life of dedication to the divine without partaking in earthly pleasures.", 
                    new AttBonus("Defense",5, "points"))
            };
        }
    }
}