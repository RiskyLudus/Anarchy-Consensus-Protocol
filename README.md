# Anarchy Consensus Protocol

## Overview

The **Anarchy Consensus Protocol** is a fully decentralized, low-latency, peer-to-peer data-sharing framework designed for real-time multiplayer games. Instead of relying on a server or a leader election model, every player holds a full copy of the game state. Specific parts of the data are managed by randomly assigned Czars, who have the authority to update their respective parts of the state. If a player drops, a pre-assigned backup player takes over the responsibility for the data—ensuring continuous, seamless gameplay.

## Key Features

- **Decentralized & Serverless**: No central server or authoritative host. Every player contributes equally to maintaining and updating the game state.
- **Instant Czar Reallocation**: If a player (Czar) leaves the game, a pre-assigned backup Czar immediately takes over. No time-consuming election process is needed.
- **Low-Latency State Updates**: The system prioritizes optimistic replication to reduce the need for frequent confirmations, ensuring faster gameplay updates.
- **Efficient Gossip Protocol**: Changes to the game state are propagated using a lightweight gossip protocol, ensuring quick syncing without flooding the network.
- **Fault-Tolerant**: Redundancy is built into the system through backup Czars, providing automatic failover when players disconnect.

## How It Works

### Data Sharding and Czar Management

The game state is divided into shards, where each shard represents a part of the game data (e.g., player stats, objects, events). Every player holds a full copy of the game state, but only the Czar of a shard has the authority to update that shard.

- **Czars**: Each shard has one assigned Czar at any given time who can make changes to the shard's data.
- **Backup Czars**: Each shard has a pre-determined list of backups, ensuring that if a Czar drops from the game, responsibility is seamlessly transferred to the next available player.

### Consensus Mechanism

To maintain data integrity, a consensus mechanism is used to resolve conflicts when multiple Czars attempt to update the same data. Each update includes a version number, and changes are validated based on:

- **Majority Vote**: Critical updates are confirmed by a majority of Czars to ensure consistency.

### Peer-to-Peer Communication

The Anarchy Consensus System operates in a fully decentralized environment, using peer-to-peer (P2P) connections. Each player communicates directly with every other player to share data updates, eliminating single points of failure and distributing the workload evenly across all participants.

- **UDP-Based Communication**: The system uses UDP (User Datagram Protocol) for fast, low-latency communication of game data.
- **Optimistic Replication**: Czars commit changes locally and broadcast updates to the rest of the network, minimizing lag while ensuring that necessary updates are communicated efficiently.

### Reallocation Protocol

When a player (Czar) leaves the game, their responsibilities are automatically transferred to the next available backup Czar using a reallocation protocol that includes:

- **Heartbeat System**: Czars send periodic updates about their status. If a heartbeat is missed, the next player in line takes over.

### Delta Updates

To optimize data transmission, the protocol employs delta updates, where only changes (deltas) are sent instead of the entire game state. This reduces the data being transmitted and enhances efficiency.

### Adaptive Rate Control

The protocol implements adaptive rate control, adjusting the frequency of updates based on network performance. If latency increases, the update frequency is reduced to maintain a smooth experience while ensuring that important updates still get communicated in a timely manner.

### Shard Splitting/Merging

As player counts change, the system allows for dynamic shard splitting and merging. If a shard becomes too large, it can be split into smaller shards managed by new Czars, while smaller shards can be merged to optimize management. This process ensures that Czars are assigned efficiently without leaving shards unassigned.

### Dynamic Czar Assignment

Czar assignment is dynamically adjusted based on player availability and performance metrics. This process is coordinated with the reallocation protocol to avoid confusion regarding responsibilities during transitions, ensuring that the most reliable players are assigned as Czars as the player pool changes.

### State Validation

Each update is validated to prevent tampering through:

- **Digital Signatures**: Updates are signed by the Czar's cryptographic key.
- **Checksum Verification**: Players validate state changes against a checksum or hash of the previous state.

## Conclusion

The Anarchy Consensus Protocol aims to provide a robust framework for real-time multiplayer games, ensuring seamless gameplay and resilience in a decentralized environment.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
