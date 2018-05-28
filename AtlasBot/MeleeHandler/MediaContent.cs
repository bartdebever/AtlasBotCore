using System;
using System.Collections.Generic;
using System.Text;

namespace MeleeHandler
{
    public class MediaContent
    {
        public string Get2018GuideByCharacterName(string name)
        {
            switch (name.ToLower())
            {
                case "general":
                    return "https://www.youtube.com/watch?v=ZrHV45Xvs28";
                case "bowser":
                    return "https://www.youtube.com/watch?v=uCKo18bgc24";
                case "donkey kong":
                    return "https://www.youtube.com/watch?v=8y_MdNQuZB0";
                case "docter mario":
                    return "https://www.youtube.com/watch?v=JtPtMkv1dkc";
                case "falco":
                    return "https://www.youtube.com/watch?v=KSPBZSZMxyU";
                case "captain falcon":
                    return "https://www.youtube.com/watch?v=PAF69hGJjdQ";
                case "fox":
                    return "https://www.youtube.com/watch?v=8faKkkSwF6Y";
                case "ganondorf":
                    return "https://www.youtube.com/watch?v=IBNlPEOwVuQ";
                case "mr game and watch":
                    return "https://www.youtube.com/watch?v=7JecWDn8qt4";
                case "ice climbers":
                    return "https://www.youtube.com/watch?v=jQuf7Yhy0sw";
                case "jigglypuff":
                    return "https://www.youtube.com/watch?v=NYpagxWLcW8";
                case "kirby":
                    return "https://www.youtube.com/watch?v=nm5aoPuptEU";
                case "link":
                    return "https://www.youtube.com/watch?v=X2Zvvc2_Xeg";
                case "luigi":
                    return "https://www.youtube.com/watch?v=u6zqeVEfQzo";
                case "mario":
                    return "https://www.youtube.com/watch?v=CRi6A1uB_Rw";
                case "marth":
                    return "https://www.youtube.com/watch?v=LhBoWyWyrb8";
                case "mewtwo":
                    return "https://www.youtube.com/watch?v=qZS3Tk1_k80";
                case "ness":
                    return "https://www.youtube.com/watch?v=qw73OvAKdF0";
                case "peach":
                    return "https://www.youtube.com/watch?v=v4VFJveeYPM";
                case "pichu":
                    return "https://www.youtube.com/watch?v=0jWeLW1cMTo";
                case "pikachu":
                    return "https://www.youtube.com/watch?v=jkllpSIhSvo";
                case "roy":
                    return "https://www.youtube.com/watch?v=NNy2LziSRZM";
                case "samus":
                    return "https://www.youtube.com/watch?v=U7JMGyhWv60";
                case "sheik":
                    return "https://www.youtube.com/watch?v=RKkwQdrLm_k";
                case "yoshi":
                    return "https://www.youtube.com/watch?v=p4gvLKc5CpQ";
                case "young link":
                    return "https://www.youtube.com/watch?v=aikFXS69Wv0";
                case "zelda":
                    return "https://www.youtube.com/watch?v=6JHod7Fk878";
                case "glitches":
                    return "https://www.youtube.com/watch?v=iQ8m22sgtSw";
            }
            return null;
        }
    }
}
