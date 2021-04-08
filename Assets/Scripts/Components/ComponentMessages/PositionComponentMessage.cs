using Mirror;
using UnityEngine;

public struct PositionComponentMessage : NetworkMessage
{
	public int worldId;
	public int entityID;
	public Vector3 Value;
	public string hi { get; }
}