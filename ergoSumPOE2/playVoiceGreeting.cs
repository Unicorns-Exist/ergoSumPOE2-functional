using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ergoSumPOE2
{
    class playVoiceGreeting
    {// start of class

        //void method to play the sound named greet

        public void greet()
        {
            try
            {
                string auto_path = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug\", @"\greet.wav");

                // create an instance for the soundPlayer class
                SoundPlayer greetMe = new SoundPlayer(auto_path);

                // play ssound
                greetMe.Play();
            }
            catch (Exception ex)
            {
                // silently fail - don't crash the app if audio is missing
                System.Diagnostics.Debug.WriteLine("Audio error: " + ex.Message);
            }


        }

    }// end of class
}