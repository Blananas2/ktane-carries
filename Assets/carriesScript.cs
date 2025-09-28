using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Rnd = UnityEngine.Random;

public class carriesScript : MonoBehaviour
{
    public KMBombModule Module;
    public KMAudio Audio;

    public TextMesh[] NumberTexts;
    public TextMesh[] LetterTexts;
    public TextMesh InputText;
    public KMSelectable[] ButtonSels;
    public Material[] ButtonMats;

    private readonly string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    //i don't think this word list will ever be in a state i'm happy with - anything that is *obviously* objectionable is gone but there are plenty that i don't consider words, but i consider my own knowledge too arbitrary and restrictive to be worth taking at all seriously for this.
    private static readonly string[] wordlist = { "AAH", "ABS", "ACE", "ACT", "ADD", "ADO", "ADS", "AFT", "AGE", "AGO", "AHA", "AID", "AIM", "AIR", "ALE", "ALL", "AMP", "AND", "ANT", "ANY", "APE", "APP", "APT", "ARC", "ARE", "ARK", "ARM", "ART", "ASH", "ASK", "ASP", "ATE", "AWE", "AXE", "AYE", "BAA", "BAD", "BAG", "BAN", "BAR", "BAT", "BAY", "BED", "BEE", "BEG", "BET", "BIB", "BID", "BIG", "BIN", "BIT", "BIZ", "BOA", "BOB", "BOD", "BOG", "BOO", "BOP", "BOT", "BOW", "BOX", "BOY", "BRA", "BRO", "BRR", "BUB", "BUD", "BUG", "BUM", "BUN", "BUS", "BUT", "BUY", "BYE", "CAB", "CAM", "CAN", "CAP", "CAR", "CAT", "CAW", "COB", "COD", "COG", "CON", "COO", "COP", "COT", "COW", "COY", "CRY", "CUB", "CUE", "CUP", "CUT", "DAB", "DAD", "DAM", "DAY", "DEF", "DEN", "DEW", "DID", "DIE", "DIG", "DIM", "DIP", "DOC", "DOE", "DOG", "DOH", "DON", "DOS", "DOT", "DRY", "DUB", "DUD", "DUE", "DUG", "DUH", "DUN", "DUO", "DYE", "EAR", "EAT", "EBB", "EEK", "EEL", "EFF", "EGG", "EGO", "ELF", "ELK", "EMO", "EMU", "END", "EON", "ERA", "ERE", "ERR", "EVE", "EWE", "EWW", "EYE", "FAB", "FAD", "FAN", "FAR", "FAT", "FAX", "FED", "FEE", "FEW", "FEZ", "FIB", "FIG", "FIN", "FIR", "FIT", "FIX", "FLU", "FLY", "FOB", "FOE", "FOG", "FOR", "FOX", "FRY", "FUN", "FUR", "GAG", "GAL", "GAP", "GAS", "GAY", "GEE", "GEL", "GEM", "GEN", "GET", "GIG", "GIN", "GIT", "GNU", "GOD", "GOO", "GOT", "GUM", "GUN", "GUT", "GUY", "GYM", "HAD", "HAG", "HAH", "HAM", "HAS", "HAT", "HAY", "HEN", "HER", "HEX", "HEY", "HID", "HIM", "HIP", "HIS", "HIT", "HMM", "HOE", "HOG", "HON", "HOP", "HOT", "HOW", "HUB", "HUE", "HUG", "HUH", "HUM", "HUT", "ICE", "ICK", "ICY", "IDS", "IFS", "ILK", "ILL", "IMP", "INK", "INN", "INS", "ION", "IRE", "IRK", "ISM", "ITS", "IVY", "JAB", "JAG", "JAM", "JAR", "JAW", "JAY", "JET", "JIG", "JOB", "JOG", "JOT", "JOY", "JUG", "JUT", "KEG", "KEN", "KEY", "KID", "KIN", "KIT", "LAB", "LAD", "LAG", "LAP", "LAS", "LAW", "LAX", "LAY", "LED", "LEG", "LET", "LIB", "LID", "LIE", "LIP", "LIT", "LOB", "LOG", "LOO", "LOT", "LOW", "LUG", "LUV", "MAC", "MAD", "MAG", "MAM", "MAN", "MAP", "MAS", "MAT", "MAW", "MAX", "MAY", "MED", "MEH", "MEN", "MET", "MEW", "MHM", "MIC", "MID", "MIL", "MIX", "MOB", "MOD", "MOI", "MOM", "MOO", "MOP", "MOW", "MUD", "MUG", "MUM", "NAB", "NAG", "NAH", "NAN", "NAP", "NAY", "NET", "NEW", "NIB", "NIL", "NIP", "NIT", "NOB", "NOD", "NOR", "NOT", "NOW", "NTH", "NUB", "NUN", "NUT", "OAF", "OAK", "OAR", "OAT", "ODD", "ODE", "OFF", "OHM", "OIL", "OLD", "OLE", "ONE", "OOH", "OPS", "OPT", "ORB", "ORC", "ORE", "OUR", "OUT", "OWE", "OWL", "OWN", "PAD", "PAL", "PAN", "PAP", "PAR", "PAS", "PAT", "PAW", "PAY", "PEA", "PEE", "PEG", "PEN", "PEP", "PER", "PET", "PEW", "PIC", "PIE", "PIG", "PIN", "PIP", "PIT", "PIX", "PLY", "POD", "POM", "POO", "POP", "POT", "POW", "POX", "PRO", "PRY", "PUB", "PUG", "PUN", "PUP", "PUS", "PUT", "PWN", "RAD", "RAG", "RAH", "RAM", "RAN", "RAP", "RAT", "RAW", "RAY", "RED", "REF", "REG", "REP", "REV", "RIB", "RID", "RIG", "RIM", "RIP", "ROB", "ROD", "ROO", "ROT", "ROW", "RUB", "RUE", "RUG", "RUM", "RUN", "RUT", "RYE", "SAC", "SAD", "SAG", "SAP", "SAT", "SAW", "SAX", "SAY", "SEA", "SEC", "SEE", "SET", "SEW", "SHE", "SHH", "SHY", "SIC", "SIM", "SIN", "SIP", "SIR", "SIS", "SIT", "SIX", "SKA", "SKI", "SKY", "SLY", "SOB", "SOD", "SON", "SOP", "SOT", "SOW", "SOY", "SPA", "SPY", "STY", "SUB", "SUE", "SUM", "SUN", "SUP", "TAB", "TAD", "TAG", "TAN", "TAP", "TAR", "TAT", "TAX", "TEA", "TED", "TEE", "TEN", "THE", "THO", "THY", "TIC", "TIE", "TIL", "TIN", "TIP", "TIS", "TOE", "TON", "TOO", "TOP", "TOT", "TOW", "TOY", "TRY", "TUB", "TUG", "TUM", "TUX", "TWO", "UGH", "UNI", "UPS", "URN", "USE", "UTE", "VAC", "VAN", "VAT", "VEG", "VET", "VEX", "VIA", "VOW", "WAD", "WAG", "WAR", "WAS", "WAX", "WAY", "WEB", "WED", "WEE", "WET", "WHO", "WHY", "WIG", "WIN", "WIT", "WOE", "WOK", "WON", "WOO", "WOT", "WOW", "WRY", "YAK", "YAM", "YAP", "YAW", "YAY", "YEA", "YEN", "YEP", "YES", "YET", "YIN", "YIP", "YOU", "YUK", "YUM", "YUP", "ZAP", "ZIP", "ZIT", "ZOO" };
    private string chosenWord;
    private int attps = 1;
    private string submittedLetters = "";
    private int currentNum = 1;
    private string currentBin = "1";
    private int correctNum = -1;
    private string correctBin = "";

    private int moduleId;
    private static int moduleIdCounter = 1;
    private bool moduleSolved;

    private void Start()
    {
        moduleId = moduleIdCounter++;
        foreach (KMSelectable button in ButtonSels)
        {
            button.OnInteract += delegate ()
            {
                ButtonPress(button);
                return false;
            };
        }
        foreach (var n in NumberTexts)
            n.gameObject.SetActive(false);
        foreach (var l in LetterTexts)
            l.gameObject.SetActive(false);
        InputText.gameObject.SetActive(false);

        Module.OnActivate += Activate;

    retry:
        int a = Rnd.Range(0, 100000);
        int b = Rnd.Range(0, 100000);
        int c = Rnd.Range(0, 100000);
        int d = Rnd.Range(0, 100000);

        int ba = CarryCalc(a, b);
        if (ba == 0 || ba > 26)
        {
            attps++;
            goto retry;
        }
        int ab = a + b;
        int cb = CarryCalc(ab, c);
        if (cb == 0 || cb > 26)
        {
            attps++;
            goto retry;
        }
        int bc = ab + c;
        int dc = CarryCalc(bc, d);
        if (dc == 0 || dc > 26)
        {
            attps++;
            goto retry;
        }

        chosenWord = alphabet[ba - 1].ToString() + alphabet[cb - 1] + alphabet[dc - 1];
        if (!wordlist.Contains(chosenWord)) //append `|| chosenWord != "?"` where `??` is the word (it MUST be in the list!) to rig :]
        {
            attps++;
            goto retry;
        }

        Debug.LogFormat("<Carries #{0}> Attempts: {1}", moduleId, attps);
        var nums = (new int[] { a, b, c, d }).Select(i => new int[]
        {
            i / 10000,
            i / 1000 % 10,
            i / 100 % 10,
            i / 10 % 10,
            i % 10
        }).SelectMany(i => i).ToArray();

        for (int i = 0; i < nums.Length; i++)
            NumberTexts[i].text = nums[i].ToString();

        Debug.LogFormat("[Carries #{0}] Numbers: {1} + {2} + {3} + {4}", moduleId, a, b, c, d);
        Debug.LogFormat("[Carries #{0}] Carries: {1}, {2}, {3}", moduleId, Convert.ToString(ba, 2).PadLeft(5, '0'), Convert.ToString(cb, 2).PadLeft(5, '0'), Convert.ToString(dc, 2).PadLeft(5, '0')); //fuck this line in particular why why hwy hywhwy
        Debug.LogFormat("[Carries #{0}] Word is {1}", moduleId, chosenWord);

        correctNum = alphabet.IndexOf(chosenWord[0]) + 1;
        correctBin = Convert.ToString(correctNum, 2);
    }

    private void Activate()
    {
        Audio.PlaySoundAtTransform("Startup", transform);
        StartCoroutine(StartupAnimation());
    }

    private IEnumerator StartupAnimation()
    {
        var manhatDistsFromTL = Enumerable.Range(0, 20).Select(i => i % 5 + i / 5).ToArray();
        for (int i = 0; i < 8; i++)
        {
            var dists = Enumerable.Range(0, 20).Where(x => manhatDistsFromTL[x] == i).ToArray();
            for (int t = 0; t < dists.Length; t++)
                NumberTexts[dists[t]].gameObject.SetActive(true);
            yield return new WaitForSeconds(0.15f);
        }
        InputText.gameObject.SetActive(true);
        for (int j = 0; j < 3; j++)
            LetterTexts[j].gameObject.SetActive(true);
    }

    private int CarryCalc(int p, int q)
    {
        int[] f = { 0, 0, 0, 0, 0 };
        for (int x = 0; x < 5; x++)
        {
            int w = (int)Math.Pow(10, x + 1);
            if ((p % w + q % w) >= w)
                f[4 - x] = 1;
        }
        return f[0] * 16 + f[1] * 8 + f[2] * 4 + f[3] * 2 + f[4];
    }

    private void ButtonPress(KMSelectable button)
    {
        button.AddInteractionPunch(0.5f);
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, button.transform);
        if (moduleSolved)
            return;
        for (int i = 0; i < ButtonSels.Length; i++)
        {
            if (ButtonSels[i] == button)
            {
                if (i == 0)
                {
                    if (currentNum == correctNum)
                    {
                        submittedLetters += chosenWord[submittedLetters.Length];
                        currentNum = 1;
                        if (submittedLetters == chosenWord)
                        {
                            InputText.text = chosenWord;
                            for (int x = 0; x < 3; x++)
                                LetterTexts[x].text = null;
                            Module.HandlePass();
                            Debug.LogFormat("[Carries #{0}] Correct word submitted, module solved.", moduleId);
                        }
                        else
                        {
                            correctNum = alphabet.IndexOf(chosenWord[submittedLetters.Length]) + 1;
                            correctBin = Convert.ToString(correctNum, 2);
                            currentNum = 1;
                            currentBin = "1";
                            for (int x = 0; x < 3; x++)
                                LetterTexts[x].text = alphabet[x].ToString();
                            InputText.text = submittedLetters + "¹";
                        }
                    }
                    else
                    {
                        Debug.LogFormat("[Carries #{0}] Attempted to submit a{1} {2} in position {3}, which is wrong. Strike!", moduleId, "AEFHILMNORSX".IndexOf(alphabet[currentNum - 1]) == -1 ? "" : "n", alphabet[currentNum - 1], submittedLetters.Length + 1); //i don't like this one either but it's partially my fault..
                        Module.HandleStrike();
                    }
                }
                else
                {
                    if (correctBin.StartsWith(Convert.ToString(currentNum * 2 + (i == 1 ? 0 : 1), 2)))
                    {
                        currentNum = currentNum * 2 + (i == 1 ? 0 : 1);
                        currentBin += (i == 1) ? "0" : "1";
                        LetterTexts[0].text = alphabet[currentNum - 1].ToString();
                        LetterTexts[1].text = (currentNum * 2 > 26) ? null : alphabet[currentNum * 2 - 1].ToString();
                        LetterTexts[2].text = (currentNum * 2 + 1 > 26) ? null : alphabet[currentNum * 2].ToString();
                        InputText.text = submittedLetters + currentBin.Replace("0", "⁰").Replace("1", "¹");
                    }
                    else
                    {
                        Debug.LogFormat("[Carries #{0}] Attempted to start a binary number with {1} in position {2}, which is wrong. Strike!", moduleId, currentBin + ((i == 1) ? "0" : "1"), submittedLetters.Length + 1);
                        Module.HandleStrike();
                    }
                }
            }
        }
    }

#pragma warning disable 0414
    private readonly string TwitchHelpMessage = "!{0} command";
#pragma warning restore 0414

    private IEnumerator ProcessTwitchCommand(string command)
    {
        yield break;
    }

    private IEnumerator TwitchHandleForcedSolve()
    {
        yield break;
    }
}
