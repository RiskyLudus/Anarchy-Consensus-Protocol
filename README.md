# Anarchy Consensus System

## Overview

The **Anarchy Consensus System** is a fully decentralized, low-latency, peer-to-peer data-sharing framework designed for real-time multiplayer games. Instead of relying on a server or a leader election model, every player holds a full copy of the game state. Specific parts of the data are managed by randomly assigned **Czars**, who have the authority to update their respective parts of the state. If a player drops, a pre-assigned backup player takes over the responsibility for the data—ensuring continuous, seamless gameplay.

### Key Features:

- **Decentralized & Serverless**: No central server or authoritative host. Every player contributes equally to maintaining and updating the game state.
- **Instant Czar Reallocation**: If a player (Czar) leaves the game, a pre-assigned backup Czar immediately takes over. No time-consuming election process is needed.
- **Low-Latency State Updates**: The system prioritizes optimistic replication to reduce the need for frequent confirmations, ensuring faster gameplay updates.
- **Efficient Gossip Protocol**: Changes to the game state are propagated using a lightweight gossip protocol, ensuring quick syncing without flooding the network.
- **Fault-Tolerant**: Redundancy is built into the system through backup Czars, providing automatic failover when players disconnect.

---

## How It Works

### Data Sharding and Czar Management

The game state is divided into **shards**, where each shard represents a part of the game data (e.g., player stats, objects, events). Every player holds a full copy of the game state, but only the **Czar** of a shard has the authority to update that shard.

- **Czars**: Each shard has one assigned Czar at any given time who can make changes to the shard's data.
- **Backup Czars**: Each shard has a pre-determined list of backups, ensuring that if a Czar drops from the game, responsibility is seamlessly transferred to the next available player.

### Peer-to-Peer Communication

The **Anarchy Consensus System** operates in a fully decentralized environment, using **peer-to-peer (P2P) connections**. Each player communicates directly with every other player to share data updates, without needing to rely on a server. This eliminates single points of failure and distributes the workload evenly across all participants.

- **UDP-based communication**: The system uses UDP (User Datagram Protocol) for fast, low-latency communication of game data.
- **Optimistic replication**: Czars commit changes locally and broadcast updates to the rest of the network, reducing the need for confirmation and minimizing lag.

### Czar Reallocation

When a player (Czar) leaves the game, their responsibilities are automatically transferred to the next available backup Czar. This ensures that the system remains functional even when players disconnect or reconnect.

```csharp
// Example Czar Reallocation Code

void HandlePlayerDrop(ulong droppedPlayerId)
{
    foreach (var shard in shardCzars)
    {
        if (shard.Value == droppedPlayerId)
        {
            // Reassign the shard to the next backup Czar
            ulong newCzar = backupCzars[shard.Key].Dequeue();
            shardCzars[shard.Key] = newCzar;
            Debug.Log($"Reassigned shard {shard.Key} to new Czar: {newCzar}");
        }
    }
}
