using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class BoneInteraction : MonoBehaviour
{
    public string boneName;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    public Transform canvasWorld;

    public RectTransform backgroundPanel;

    public Vector3 posicaoCentral;
    public Vector3 posicaoLateral;

    public Vector2 tamanhoInicial;
    public Vector2 tamanhoExpandido;

    private Renderer rend;
    private Color originalColor;

    private static BoneInteraction lastSelected;

    Dictionary<string, string> boneDescriptions =
        new Dictionary<string, string>()
    {
        {
            "Ulna e Rádio Esquerdo",
            "Função:\nPermitir os movimentos do antebraço e da mão.\n\nCuriosidade:\nO rádio gira em torno da ulna para possibilitar a rotação do braço."
        },

        {
            "Ulna e Rádio Direito",
            "Função:\nPermitir os movimentos do antebraço e da mão.\n\nCuriosidade:\nO rádio gira em torno da ulna para possibilitar a rotação do braço."
        },

        {
            "Pé Esquerdo",
            "Função:\nSustentar o corpo e auxiliar na locomoção.\n\nCuriosidade:\nCada pé humano possui 26 ossos."
        },

        {
            "Pé Direito",
            "Função:\nSustentar o corpo e auxiliar na locomoção.\n\nCuriosidade:\nCada pé humano possui 26 ossos."
        },

        {
            "Fêmur Esquerdo",
            "Função:\nSustentar o peso corporal e auxiliar na locomoção.\n\nCuriosidade:\nÉ o maior e mais resistente osso do corpo humano."
        },

        {
            "Fêmur Direito",
            "Função:\nSustentar o peso corporal e auxiliar na locomoção.\n\nCuriosidade:\nÉ o maior e mais resistente osso do corpo humano."
        },

        {
            "Tíbia e Fíbula Esquerda",
            "Função:\nSustentar a perna e auxiliar nos movimentos.\n\nCuriosidade:\nA tíbia suporta grande parte do peso do corpo."
        },

        {
            "Tíbia e Fíbula Direita",
            "Função:\nSustentar a perna e auxiliar nos movimentos.\n\nCuriosidade:\nA tíbia suporta grande parte do peso do corpo."
        },

        {
            "Caixa Torácica",
            "Função:\nProteger órgãos como coração e pulmões.\n\nCuriosidade:\nA caixa torácica é formada por 12 pares de costelas."
        },

        {
            "Úmero Esquerdo",
            "Função:\nConectar o ombro ao cotovelo.\n\nCuriosidade:\nO úmero é o principal osso do braço."
        },

        {
            "Úmero Direito",
            "Função:\nConectar o ombro ao cotovelo.\n\nCuriosidade:\nO úmero é o principal osso do braço."
        },

        {
            "Clavícula Esquerda",
            "Função:\nConectar o braço ao tronco.\n\nCuriosidade:\nA clavícula é um dos ossos mais fraturados do corpo."
        },

        {
            "Clavícula Direita",
            "Função:\nConectar o braço ao tronco.\n\nCuriosidade:\nA clavícula é um dos ossos mais fraturados do corpo."
        },

        {
            "Ilíaco",
            "Função:\nSustentar o tronco e proteger órgãos da pelve.\n\nCuriosidade:\nÉ formado pela fusão do ílio, ísquio e púbis."
        },

        {
            "Crânio",
            "Função:\nProteger o cérebro.\n\nCuriosidade:\nO crânio é formado por 22 ossos."
        },

        {
            "Mandíbula",
            "Função:\nPermitir a mastigação e a fala.\n\nCuriosidade:\nÉ o único osso móvel do crânio."
        },

        {
            "Coluna Vertebral",
            "Função:\nSustentar o corpo e proteger a medula espinhal.\n\nCuriosidade:\nA coluna vertebral possui 33 vértebras."
        },

        {
            "Mão Esquerda",
            "Função:\nPermitir movimentos precisos e manipulação de objetos.\n\nCuriosidade:\nCada mão possui 27 ossos."
        },

        {
            "Mão Direita",
            "Função:\nPermitir movimentos precisos e manipulação de objetos.\n\nCuriosidade:\nCada mão possui 27 ossos."
        }
    };

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;

        posicaoCentral = canvasWorld.position;

        posicaoLateral = posicaoCentral + new Vector3(2f, -0.4f, 0f);

        titleText.text = "Selecione um osso";

        descriptionText.text =
            "Clique em um osso para visualizar informações.";

        tamanhoInicial = new Vector2(350, 120);

        tamanhoExpandido = new Vector2(400, 300);

        backgroundPanel.sizeDelta = tamanhoInicial;
    }

    void OnMouseDown()
    {
        // resetar anterior
        if (lastSelected != null)
        {
            lastSelected.ResetColor();
        }

        canvasWorld.position = posicaoLateral;

        backgroundPanel.sizeDelta = tamanhoExpandido;

        // título
        titleText.text = boneName;

        // descrição
        if (boneDescriptions.ContainsKey(boneName))
            descriptionText.text = boneDescriptions[boneName];
        else
            descriptionText.text = "Informações não disponíveis.";

        // destacar osso
        rend.material.color = Color.yellow;

        lastSelected = this;
    }

    void ResetColor()
    {
        rend.material.color = originalColor;
    }
}