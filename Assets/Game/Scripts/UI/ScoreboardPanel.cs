using UnityEngine;
using UnityEngine.UI;

public class ScoreboardPanel : MonoBehaviour
{
    public string name;

    [System.Serializable]
    public struct FoodText
    {
        public Text nasiKuning;
        public Text telur;
        public Text ayam;
        public Text ikan;
        public Text perkedel;
        public Text urap;
        public Text lalapan;
        public Text telurIris;
        public Text sambal;
    }

    public FoodText itemCollect;
    public FoodText jumlahTotal;
    public Text total;
    
    public void SetTotalReward(int total)
    {
        this.total.text = total.ToString();
    }

    public void SetItemCollect(string name, int total)
    {
        switch (name)
        {
            case "Nasi Kuning":
                itemCollect.nasiKuning.text = total.ToString();
                break;
            case "Telur":
                itemCollect.telur.text = total.ToString();
                break;
            case "Ayam":
                itemCollect.ayam.text = total.ToString();
                break;
            case "Ikan":
                itemCollect.ikan.text = total.ToString();
                break;
            case "Perkedel":
                itemCollect.perkedel.text = total.ToString();
                break;
            case "Urap":
                itemCollect.urap.text = total.ToString();
                break;
            case "Lalapan":
                itemCollect.lalapan.text = total.ToString();
                break;
            case "Telur Iris":
                itemCollect.telurIris.text = total.ToString();
                break;
            case "Sambal":
                itemCollect.sambal.text = total.ToString();
                break;
        }
    }

    public void SetJumlahTotal(string name, int total)
    {
        switch (name)
        {
            case "Nasi Kuning":
                jumlahTotal.nasiKuning.text = total.ToString();
                break;
            case "Telur":
                jumlahTotal.telur.text = total.ToString();
                break;
            case "Ayam":
                jumlahTotal.ayam.text = total.ToString();
                break;
            case "Ikan":
                jumlahTotal.ikan.text = total.ToString();
                break;
            case "Perkedel":
                jumlahTotal.perkedel.text = total.ToString();
                break;
            case "Urap":
                jumlahTotal.urap.text = total.ToString();
                break;
            case "Lalapan":
                jumlahTotal.lalapan.text = total.ToString();
                break;
            case "Telur Iris":
                jumlahTotal.telurIris.text = total.ToString();
                break;
            case "Sambal":
                jumlahTotal.sambal.text = total.ToString();
                break;
        }
    }
}
