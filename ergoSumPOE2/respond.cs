using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ergoSumPOE2
{
    class respond
    {// start of class

        public respond(ArrayList reply, ArrayList ignore)
        {//start of constructor

            answers(reply);
            words(ignore);


        }//end of constructor

        //method to store the list of words
        private void words(ArrayList ignoring)
        {//
         //ignoring questions
            ignoring.Add("a");
            ignoring.Add("about");
            ignoring.Add("above");
            ignoring.Add("across");
            ignoring.Add("after");
            ignoring.Add("afterwards");
            ignoring.Add("again");
            ignoring.Add("against");
            ignoring.Add("all");
            ignoring.Add("almost");
            ignoring.Add("alone");
            ignoring.Add("along");
            ignoring.Add("already");
            ignoring.Add("also");
            ignoring.Add("although");
            ignoring.Add("always");
            ignoring.Add("am");
            ignoring.Add("among");
            ignoring.Add("amongst");
            ignoring.Add("amount");
            ignoring.Add("an");
            ignoring.Add("and");
            ignoring.Add("another");
            ignoring.Add("any");
            ignoring.Add("anyhow");
            ignoring.Add("anyone");
            ignoring.Add("anything");
            ignoring.Add("anyway");
            ignoring.Add("anywhere");
            ignoring.Add("are");
            ignoring.Add("around");
            ignoring.Add("as");
            ignoring.Add("at");
            ignoring.Add("back");
            ignoring.Add("be");
            ignoring.Add("became");
            ignoring.Add("because");
            ignoring.Add("become");
            ignoring.Add("becomes");
            ignoring.Add("becoming");
            ignoring.Add("been");
            ignoring.Add("before");
            ignoring.Add("beforehand");
            ignoring.Add("behind");
            ignoring.Add("being");
            ignoring.Add("below");
            ignoring.Add("beside");
            ignoring.Add("besides");
            ignoring.Add("between");
            ignoring.Add("beyond");
            ignoring.Add("both");
            ignoring.Add("but");
            ignoring.Add("by");
            ignoring.Add("can");
            ignoring.Add("cannot");
            ignoring.Add("could");
            ignoring.Add("did");
            ignoring.Add("do");
            ignoring.Add("does");
            ignoring.Add("doing");
            ignoring.Add("done");
            ignoring.Add("down");
            ignoring.Add("during");
            ignoring.Add("each");
            ignoring.Add("either");
            ignoring.Add("else");
            ignoring.Add("elsewhere");
            ignoring.Add("enough");
            ignoring.Add("etc");
            ignoring.Add("even");
            ignoring.Add("ever");
            ignoring.Add("every");
            ignoring.Add("everyone");
            ignoring.Add("everything");
            ignoring.Add("everywhere");
            ignoring.Add("except");
            ignoring.Add("few");
            ignoring.Add("first");
            ignoring.Add("for");
            ignoring.Add("former");
            ignoring.Add("formerly");
            ignoring.Add("from");
            ignoring.Add("further");
            ignoring.Add("had");
            ignoring.Add("has");
            ignoring.Add("have");
            ignoring.Add("having");
            ignoring.Add("he");
            ignoring.Add("hence");
            ignoring.Add("her");
            ignoring.Add("here");
            ignoring.Add("hereafter");
            ignoring.Add("hereby");
            ignoring.Add("herein");
            ignoring.Add("hereupon");
            ignoring.Add("hers");
            ignoring.Add("herself");
            ignoring.Add("him");
            ignoring.Add("himself");
            ignoring.Add("his");
            ignoring.Add("how");
            ignoring.Add("however");
            ignoring.Add("i");
            ignoring.Add("if");
            ignoring.Add("in");
            ignoring.Add("indeed");
            ignoring.Add("inside");
            ignoring.Add("instead");
            ignoring.Add("into");
            ignoring.Add("is");
            ignoring.Add("it");
            ignoring.Add("its");
            ignoring.Add("itself");
            ignoring.Add("last");
            ignoring.Add("later");
            ignoring.Add("latter");
            ignoring.Add("latterly");
            ignoring.Add("least");
            ignoring.Add("less");
            ignoring.Add("lot");
            ignoring.Add("many");
            ignoring.Add("may");
            ignoring.Add("me");
            ignoring.Add("meanwhile");
            ignoring.Add("might");
            ignoring.Add("more");
            ignoring.Add("moreover");
            ignoring.Add("most");
            ignoring.Add("mostly");
            ignoring.Add("much");
            ignoring.Add("must");
            ignoring.Add("my");
            ignoring.Add("myself");
            ignoring.Add("name");
            ignoring.Add("namely");
            ignoring.Add("neither");
            ignoring.Add("never");
            ignoring.Add("nevertheless");
            ignoring.Add("next");
            ignoring.Add("no");
            ignoring.Add("nobody");
            ignoring.Add("none");
            ignoring.Add("noone");
            ignoring.Add("nor");
            ignoring.Add("not");
            ignoring.Add("nothing");
            ignoring.Add("now");
            ignoring.Add("nowhere");
            ignoring.Add("of");
            ignoring.Add("off");
            ignoring.Add("often");
            ignoring.Add("on");
            ignoring.Add("once");
            ignoring.Add("one");
            ignoring.Add("only");
            ignoring.Add("or");
            ignoring.Add("other");
            ignoring.Add("others");
            ignoring.Add("otherwise");
            ignoring.Add("ought");
            ignoring.Add("our");
            ignoring.Add("ours");
            ignoring.Add("ourselves");
            ignoring.Add("out");
            ignoring.Add("outside");
            ignoring.Add("over");
            ignoring.Add("own");
            ignoring.Add("part");
            ignoring.Add("per");
            ignoring.Add("perhaps");
            ignoring.Add("please");
            ignoring.Add("put");
            ignoring.Add("rather");
            ignoring.Add("re");
            ignoring.Add("same");
            ignoring.Add("see");
            ignoring.Add("seem");
            ignoring.Add("seemed");
            ignoring.Add("seeming");
            ignoring.Add("seems");
            ignoring.Add("several");
            ignoring.Add("she");
            ignoring.Add("should");
            ignoring.Add("show");
            ignoring.Add("side");
            ignoring.Add("since");
            ignoring.Add("so");
            ignoring.Add("some");
            ignoring.Add("somehow");
            ignoring.Add("someone");
            ignoring.Add("something");
            ignoring.Add("sometime");
            ignoring.Add("sometimes");
            ignoring.Add("somewhere");
            ignoring.Add("still");
            ignoring.Add("such");
            ignoring.Add("take");
            ignoring.Add("than");
            ignoring.Add("that");
            ignoring.Add("the");
            ignoring.Add("their");
            ignoring.Add("theirs");
            ignoring.Add("them");
            ignoring.Add("themselves");
            ignoring.Add("then");
            ignoring.Add("thence");
            ignoring.Add("there");
            ignoring.Add("thereafter");
            ignoring.Add("thereby");
            ignoring.Add("therefore");
            ignoring.Add("therein");
            ignoring.Add("thereupon");
            ignoring.Add("these");
            ignoring.Add("they");
            ignoring.Add("this");
            ignoring.Add("those");
            ignoring.Add("though");
            ignoring.Add("through");
            ignoring.Add("throughout");
            ignoring.Add("thru");
            ignoring.Add("thus");
            ignoring.Add("to");
            ignoring.Add("together");
            ignoring.Add("too");
            ignoring.Add("toward");
            ignoring.Add("towards");
            ignoring.Add("under");
            ignoring.Add("unless");
            ignoring.Add("until");
            ignoring.Add("up");
            ignoring.Add("upon");
            ignoring.Add("us");
            ignoring.Add("used");
            ignoring.Add("very");
            ignoring.Add("via");
            ignoring.Add("was");
            ignoring.Add("we");
            ignoring.Add("well");
            ignoring.Add("were");
            ignoring.Add("what");
            ignoring.Add("whatever");
            ignoring.Add("when");
            ignoring.Add("whence");
            ignoring.Add("whenever");
            ignoring.Add("where");
            ignoring.Add("whereafter");
            ignoring.Add("whereas");
            ignoring.Add("whereby");
            ignoring.Add("wherein");
            ignoring.Add("whereupon");
            ignoring.Add("wherever");
            ignoring.Add("whether");
            ignoring.Add("which");
            ignoring.Add("while");
            ignoring.Add("whither");
            ignoring.Add("who");
            ignoring.Add("whoever");
            ignoring.Add("whole");
            ignoring.Add("whom");
            ignoring.Add("whose");
            ignoring.Add("why");
            ignoring.Add("will");
            ignoring.Add("with");
            ignoring.Add("within");
            ignoring.Add("without");
            ignoring.Add("would");
            ignoring.Add("yes");
            ignoring.Add("yet");
            ignoring.Add("hey");
            ignoring.Add("you");
            ignoring.Add("your");
            ignoring.Add("yours");
            ignoring.Add("yourself");
            ignoring.Add("yourselves");

        }//




        public void answers(ArrayList add_answers)
        {//start of method




            add_answers.Add("greeting i'm doing really well today, thanks so much for asking! it's always nice to chat with someone friendly. how are you doing today ?");
            add_answers.Add("greeting i'm feeling great today and ready to help you with anything you need. thanks for checking in! how has your day been so far ?");
            add_answers.Add("greeting i'm doing good, thank you! i hope your day is going well too. feel free to ask me anything whenever you're ready ?");


            add_answers.Add("purpose my purpose is to help educate people about cybersecurity and online safety in a simple and easy-to-understand way. i can guide you with tips, advice and answers to help you stay safer online.");
            add_answers.Add("purpose i am here to help users learn more about digital safety, cybersecurity threats and ways to protect their personal information while using the internet and technology.");
            add_answers.Add("purpose my goal is to assist people with cybersecurity awareness by explaining important topics like scams, hacking, passwords and online protection in a friendly and helpful manner.");


            add_answers.Add("cybersecurity cybersecurity is the practice of protecting computers, networks, devices and online accounts from hackers, viruses and other digital threats that can steal or damage information.");
            add_answers.Add("cybersecurity cybersecurity focuses on keeping digital systems and personal information safe from cybercriminals. it includes protecting passwords, networks, software and sensitive data from attacks.");
            add_answers.Add("cybersecurity cybersecurity is all about staying safe in the digital world by defending devices, online accounts and networks against harmful activities like hacking, scams and malware.");


            add_answers.Add("phishing phishing is a type of online scam where attackers pretend to be trusted companies or people in order to trick users into sharing passwords, banking details or other sensitive information.");
            add_answers.Add("phishing phishing attacks usually happen through fake emails, messages or websites that look real. the goal is to fool users into revealing personal or financial information.");
            add_answers.Add("phishing phishing is a cybercrime technique where scammers use deception and fake communication to make users believe they are trustworthy so they can steal important information.");


            add_answers.Add("firewall a firewall is a security system that monitors and controls incoming and outgoing network traffic based on safety rules to help protect devices and networks from threats.");
            add_answers.Add("firewall a firewall acts like a protective barrier between your device and the internet by blocking suspicious or unauthorized access that could be dangerous.");
            add_answers.Add("firewall firewalls help improve cybersecurity by filtering harmful traffic and preventing hackers or malicious software from gaining access to your computer or network.");


            add_answers.Add("password a password is a secret combination of characters used to protect your online accounts and devices from unauthorized access. strong passwords are very important for online safety.");
            add_answers.Add("password a good password should be long, unique and difficult to guess. using a mix of letters, numbers and symbols can make your accounts much more secure.");
            add_answers.Add("password passwords help keep your personal information safe online. avoid using simple words, birthdays or personal details because they are easier for hackers to guess.");


            add_answers.Add("hacked account if you think your account has been hacked, you should immediately change your password, log out of all devices and review your recent account activity for anything suspicious.");
            add_answers.Add("hacked account a compromised account can be dangerous, so it is important to contact the platform support team as soon as possible and enable extra security features like two-factor authentication.");
            add_answers.Add("hacked account if your account has been hacked, act quickly by securing your login details, checking for unusual activity and updating your recovery information to prevent further damage.");


            add_answers.Add("fraud if you notice signs of fraud or suspicious financial activity, contact your bank or service provider immediately so they can help secure your account and investigate the issue.");
            add_answers.Add("fraud fraud involves dishonest activities used to steal money or sensitive information. always monitor your accounts regularly and report anything unusual as soon as possible.");
            add_answers.Add("fraud protecting yourself from fraud includes being careful with suspicious messages, avoiding unknown links and checking your financial accounts for unauthorized transactions.");


            add_answers.Add("malicious chatbot malicious chatbots are designed to trick or manipulate users by pretending to be helpful while secretly trying to steal personal information or spread scams.");
            add_answers.Add("malicious chatbot fake or malicious chatbots may create a sense of urgency or pressure users into giving away passwords, banking information or other sensitive details.");
            add_answers.Add("malicious chatbot when interacting with chatbots online, always be cautious if the bot asks for personal information, behaves suspiciously or tries to rush you into making decisions.");


            add_answers.Add("vpn a vpn, also known as a virtual private network, helps protect your privacy and security online by encrypting your internet connection, especially when using public wi-fi.");
            add_answers.Add("vpn using a vpn can make your online activity more secure because it hides your internet traffic from hackers, cybercriminals and other people who may try to spy on your connection.");
            add_answers.Add("vpn a vpn improves online safety by creating a secure and private connection between your device and the internet, helping protect your information while browsing online.");



            //sentiment detection

            add_answers.Add("frustrated i understand that you're feeling frustrated right now, and that's completely understandable when technology or online issues are not working the way they should. don't worry, i'm here to help you work through the problem step by step until we find a solution together.");
            add_answers.Add("frustrated it's completely normal to feel frustrated when something goes wrong, especially with cybersecurity or technical issues. try not to stress too much, and let's go through everything carefully so we can fix it together.");
            add_answers.Add("frustrated i can see that this situation is frustrating for you, but don't give up yet. sometimes these problems take a little patience to solve, and i'll do my best to guide you through it clearly and calmly.");


            add_answers.Add("confused that's perfectly okay, confusion happens to everyone when learning something new or dealing with technical problems. i'll explain everything in a much simpler and clearer way so it becomes easier to understand.");
            add_answers.Add("confused no worries at all if this seems confusing right now. let me break the information down step by step and explain it in a more detailed and easy-to-follow manner for you.");
            add_answers.Add("confused i understand why this might feel confusing at first, especially with cybersecurity topics. take your time, and i'll help guide you through the explanation until it makes more sense.");


            add_answers.Add("worried it's completely understandable to feel worried in situations like this, especially when it involves your personal information or online safety. try to stay calm because many cybersecurity problems can be solved with the right steps.");
            add_answers.Add("worried i understand your concern, and it's good that you're taking online safety seriously. don't panic, because we can go through some important steps together to help secure your information and protect your accounts.");
            add_answers.Add("worried feeling worried about cybersecurity issues is normal, but remember that acting quickly and carefully can often prevent bigger problems. i'm here to help you stay safe and guide you through what to do next.");


            add_answers.Add("happy that's really wonderful to hear! i'm glad things are going well for you, and i hope your positive mood continues throughout the rest of your day.");
            add_answers.Add("happy awesome! it's always nice to hear positive news and good energy. i'm happy that things are going well, and i'm here if you need help with anything else.");
            add_answers.Add("happy i'm really happy for you! positivity can make a big difference, and it's great to know that things are working out well for you today.");


            add_answers.Add("sad i'm sorry to hear that you're feeling sad right now. difficult moments can be hard to deal with, but remember that you don't have to go through everything alone.");
            add_answers.Add("sad that sounds really difficult, and i understand why you might feel this way. try to take things slowly and focus on one step at a time, because small progress still matters.");
            add_answers.Add("sad i'm sorry things are feeling tough for you at the moment. i hope things improve soon, and remember that you can always talk to me whenever you need support or guidance.");


            add_answers.Add("angry i understand that you're feeling angry right now, especially if something frustrating or stressful has happened. let's try to focus on solving the issue together in the calmest and safest way possible.");
            add_answers.Add("angry it's completely okay to feel angry when things go wrong or become stressful. take your time, and i'll help guide you through the problem step by step so we can work toward a solution.");
            add_answers.Add("angry i can understand why this situation would make you upset or angry. try not to let the frustration overwhelm you, and let's work together to figure out the best way to fix the issue.");




        }//end of method








    }// end of class

}