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
    public TextMesh InputText;
    public KMSelectable[] ButtonSels;
    public Material[] ButtonMats;

    private readonly string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    //i don't think this word list will ever be in a state i'm happy with - anything that is *obviously* objectionable is gone but there are plenty that i don't consider words, but i consider my own knowledge too arbitrary and restrictive to be worth taking at all seriously for this.
    private static readonly string[] wordlist = { "AAH", "ABS", "ACE", "ACT", "ADD", "ADO", "ADS", "ADZ", "AFT", "AGE", "AGO", "AHA", "AID", "AIL", "AIM", "AIR", "ALE", "ALL", "AMP", "AND", "ANT", "ANY", "APE", "APP", "APT", "ARC", "ARE", "ARK", "ARM", "ART", "ASH", "ASK", "ASP", "ATE", "AUK", "AWE", "AWL", "AXE", "AYE", "BAA", "BAD", "BAG", "BAH", "BAN", "BAP", "BAR", "BAT", "BAY", "BED", "BEE", "BEG", "BET", "BIB", "BID", "BIG", "BIN", "BIT", "BIZ", "BOA", "BOB", "BOD", "BOG", "BOO", "BOP", "BOT", "BOW", "BOX", "BOY", "BRA", "BRO", "BRR", "BUB", "BUD", "BUG", "BUM", "BUN", "BUR", "BUS", "BUT", "BUY", "BYE", "CAB", "CAD", "CAM", "CAN", "CAP", "CAR", "CAT", "CAW", "COB", "COD", "COG", "CON", "COO", "COP", "COS", "COT", "COW", "COX", "COY", "CRY", "CUB", "CUD", "CUE", "CUP", "CUR", "CUT", "DAB", "DAD", "DAG", "DAL", "DAM", "DAY", "DEB", "DEF", "DEN", "DEW", "DID", "DIE", "DIG", "DIM", "DIN", "DIP", "DIS", "DOB", "DOC", "DOE", "DOG", "DOH", "DON", "DOS", "DOT", "DRY", "DUB", "DUD", "DUE", "DUG", "DUH", "DUN", "DUO", "DYE", "EAR", "EAT", "EBB", "EEK", "EEL", "EFF", "EGG", "EGO", "EKE", "ELF", "ELK", "ELM", "EMO", "EMU", "END", "EON", "ERA", "ERE", "ERR", "EVE", "EWE", "EWW", "EYE", "FAB", "FAD", "FAH", "FAN", "FAR", "FAS", "FAT", "FAX", "FED", "FEE", "FEN", "FEW", "FEY", "FEZ", "FIB", "FIG", "FIN", "FIR", "FIT", "FIX", "FLU", "FLY", "FOB", "FOE", "FOG", "FOP", "FOR", "FOX", "FRY", "FUG", "FUN", "FUR", "GAB", "GAD", "GAG", "GAL", "GAP", "GAS", "GAY", "GEE", "GEL", "GEM", "GEN", "GET", "GIG", "GIN", "GIT", "GNU", "GOB", "GOD", "GOO", "GOT", "GUM", "GUN", "GUT", "GUV", "GUY", "GYM", "GYP", "HAD", "HAG", "HAH", "HAJ", "HAM", "HAS", "HAT", "HAW", "HAY", "HEM", "HEN", "HER", "HEW", "HEX", "HEY", "HID", "HIE", "HIM", "HIP", "HIS", "HIT", "HMM", "HOB", "HOD", "HOE", "HOG", "HON", "HOP", "HOS", "HOT", "HOW", "HUB", "HUE", "HUG", "HUH", "HUM", "HUT", "ICE", "ICK", "ICY", "IDS", "IFS", "ILK", "ILL", "IMP", "INK", "INN", "INS", "ION", "IRE", "IRK", "ISM", "ITS", "IVY", "JAB", "JAG", "JAM", "JAR", "JAW", "JAY", "JET", "JIB", "JIG", "JOB", "JOG", "JOT", "JOY", "JUG", "JUS", "JUT", "KEG", "KEN", "KEY", "KID", "KIN", "KIP", "KIT", "LAB", "LAD", "LAG", "LAH", "LAM", "LAP", "LAS", "LAV", "LAW", "LAX", "LAY", "LED", "LEE", "LEG", "LEI", "LET", "LIB", "LID", "LIE", "LIP", "LIT", "LOB", "LOG", "LOO", "LOP", "LOT", "LOW", "LOX", "LUG", "LUV", "LYE", "MAC", "MAD", "MAG", "MAM", "MAN", "MAP", "MAR", "MAS", "MAT", "MAW", "MAX", "MAY", "MED", "MEG", "MEH", "MEN", "MET", "MEW", "MHM", "MIC", "MID", "MIL", "MIX", "MOB", "MOD", "MOI", "MOM", "MOO", "MOP", "MOW", "MUD", "MUG", "MUM", "NAB", "NAG", "NAH", "NAN", "NAP", "NAY", "NEE", "NET", "NEW", "NIB", "NIL", "NIP", "NIT", "NIX", "NOB", "NOD", "NOR", "NOT", "NOW", "NTH", "NUB", "NUN", "NUT", "OAF", "OAK", "OAR", "OAT", "OCH", "ODD", "ODE", "OFF", "OFT", "OHM", "OHO", "OIK", "OIL", "OLD", "OLE", "ONE", "OOH", "OPS", "OPT", "ORB", "ORC", "ORE", "OUR", "OUT", "OVA", "OWE", "OWL", "OWN", "PAD", "PAL", "PAN", "PAP", "PAR", "PAS", "PAT", "PAW", "PAY", "PEA", "PEE", "PEG", "PEN", "PEP", "PER", "PET", "PEW", "PIC", "PIE", "PIG", "PIN", "PIP", "PIT", "PIX", "PLY", "POD", "POL", "POM", "POO", "POP", "POT", "POW", "POX", "PRO", "PRY", "PUB", "PUD", "PUG", "PUN", "PUP", "PUS", "PUT", "PWN", "QUA", "RAD", "RAG", "RAH", "RAM", "RAN", "RAP", "RAT", "RAW", "RAY", "RED", "REF", "REG", "REP", "REV", "RIB", "RID", "RIG", "RIM", "RIP", "ROB", "ROD", "ROE", "ROO", "ROT", "ROW", "RUB", "RUE", "RUG", "RUM", "RUN", "RUT", "RYE", "SAC", "SAD", "SAG", "SAP", "SAT", "SAW", "SAX", "SAY", "SEA", "SEC", "SEE", "SET", "SEW", "SHE", "SHH", "SHY", "SIC", "SIM", "SIN", "SIP", "SIR", "SIS", "SIT", "SIX", "SKA", "SKI", "SKY", "SLY", "SOB", "SOD", "SOH", "SOL", "SON", "SOP", "SOT", "SOU", "SOW", "SOY", "SPA", "SPY", "STY", "SUB", "SUE", "SUM", "SUN", "SUP", "TAB", "TAD", "TAG", "TAN", "TAP", "TAR", "TAT", "TAX", "TEA", "TED", "TEE", "TEN", "THE", "THO", "THY", "TIC", "TIE", "TIL", "TIN", "TIP", "TIS", "TOD", "TOE", "TOG", "TOM", "TON", "TOO", "TOP", "TOR", "TOT", "TOW", "TOY", "TRY", "TUB", "TUG", "TUM", "TUT", "TUX", "TWO", "UGH", "UMP", "UNI", "UPS", "URN", "USE", "UTE", "VAC", "VAN", "VAT", "VEG", "VET", "VEX", "VIA", "VIE", "VIM", "VOW", "WAD", "WAG", "WAN", "WAR", "WAS", "WAX", "WAY", "WEB", "WED", "WEE", "WET", "WHO", "WHY", "WIG", "WIN", "WIT", "WOE", "WOG", "WOK", "WON", "WOO", "WOP", "WOT", "WOW", "WRY", "YAK", "YAM", "YAP", "YAW", "YAY", "YEA", "YEN", "YEP", "YER", "YES", "YET", "YEW", "YID", "YIN", "YIP", "YOB", "YON", "YOU", "YUK", "YUM", "YUP", "ZAP", "ZIP", "ZIT", "ZOO" };
    private int attps = 1;

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
        foreach (var t in NumberTexts)
            t.gameObject.SetActive(false);
        InputText.text = "";

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

        string w = alphabet[ba - 1].ToString() + alphabet[cb - 1] + alphabet[dc - 1];
        if (!wordlist.Contains(w))
        {
            attps++;
            goto retry;
        }

        Debug.Log("attps: " + attps);
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

        Debug.Log(a + "+" + b + "+" + c + "+" + d + " : " + w);
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
                // do shit with i
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
