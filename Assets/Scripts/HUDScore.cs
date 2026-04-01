using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDScore : MonoBehaviour
{
    public TextMeshProUGUI textoTela;

    void Update()
    {
        AtualizarPlacar();
    }

    void AtualizarPlacar()
    {
        string placar = "=== PLACAR ===\n";
        NetworkObject[] todosObjetos = FindObjectsOfType<NetworkObject>();
        int numeroPlayer = 1;

    foreach (NetworkObject networkObj in todosObjetos)
        {
            MovimentoController player = networkObj.GetComponent<MovimentoController>();

            if (player != null)
            {
                string marcador = networkObj.HasInputAuthority ? " (VOCÊ)" : "";
                placar += $"Player {numeroPlayer}{marcador}: {player.Score} pontos\n";
                numeroPlayer++;
            }
        }

        textoTela.text = placar;
    }
}