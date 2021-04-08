using Mirror;
using UnityEngine;

public struct PositionComponentMessage : NetworkMessage
{
	public int worldID;
	public int entityID;
	public Vector3 Value;
}