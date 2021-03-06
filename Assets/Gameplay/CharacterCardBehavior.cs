﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Store character card data in this component.
// This represents one character card during a play session, thus it can upgrade as the game goes on.
public class CharacterCardBehavior : MonoBehaviour {

	// ID of this card in this game.
	// A card will be assigned an ID when it's created.
	public int CardID { get; private set; }

	// A 64-bit int designating the card's type.
	// Call CardManager.GetCardBaseData(CardType) to get this card's base data.
	public long CardType { get; private set; }

	// Player index that currently owns the card.
	// A -1 index means that the card is currently free.
	public int Owner { get; private set; }

	// Current HP
	public int CurrentHP { get; private set; }

	// Max HP
	public int MaxHP { get; private set; }

	// Character stats
	public int[] CharacterStats { get; private set; }

	// Primary attribute values
	public int[] PrimaryAttributes { get; private set; }

	// Special abilities (ID)
	public int[] SpecialAbilities { get; private set; }

	// TODO: Add card visual so that the UI can draw this card
	// public Texture Portrait
	public string Name { get; private set; }

	// Activity log.
	public List<string> ActivityLog { get; private set; }

	// TODO: Item slot
	// public Item

	// Stores the card manager for easier future references.
	private CardManager _CardManagerRef;

	// Use this for initialization
	void Start () {
		PrimaryAttributes = new int[CardBaseData.NumPrimaryAttributes];
		SpecialAbilities = new int[CardBaseData.NumSpecialAbilities];
		ActivityLog = new List<string> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Initialize the card's data
	public void InitializeData(int cardID, CardManager manager, long cardType)
	{
		_CardManagerRef = manager;
		CardID = cardID;
		CardType = cardType;

		CardBaseData data = _CardManagerRef.GetCardBaseData (cardType);
		if (!data.Equals(CardBaseData.EmptyCard)) {
			CurrentHP = data.InitialHP;
			MaxHP = data.MaxHP;
			for (int i = 0; i < CardBaseData.NumCharacterStats; ++i) {
				CharacterStats[i] = data.CharacterStats[i];
			}
			for (int i = 0; i < CardBaseData.NumPrimaryAttributes; ++i) {
				PrimaryAttributes[i] = data.PrimaryAttributes[i];
			}
			for (int i = 0; i < CardBaseData.NumSpecialAbilities; ++i) {
				SpecialAbilities[i] = data.SpecialAbilities[i];
			}
			// Portrait = data.Portrait;
			Name = data.Name;
		}

		Owner = -1;
		ActivityLog.Clear ();
	}
}
