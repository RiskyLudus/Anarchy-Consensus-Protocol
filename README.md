# **Anarchy Consensus Protocol**

## **Overview**

The **Anarchy Consensus Protocol** is a fully decentralized, low-latency, peer-to-peer data-sharing framework designed specifically for real-time multiplayer games. Unlike traditional server-based or leader-election models, this protocol distributes the game state equally among all players. Specific data shards are managed by assigned **Czars**, who have the authority to update their respective shards. When a Czar leaves, a pre-assigned **Backup Czar** seamlessly takes over the responsibility, ensuring uninterrupted gameplay and state synchronization.

By combining lightweight communication protocols, adaptive performance optimizations, and fault-tolerant mechanisms, the **Anarchy Consensus Protocol** enables scalable and resilient multiplayer experiences.

---

## **Key Features**

- **Decentralized and Serverless**: Players collectively maintain the game state without relying on a central server or host.
- **Dynamic Czar Reallocation**: Backup Czars ensure immediate reassignment of responsibilities when a player disconnects.
- **Low-Latency State Updates**: Optimistic replication ensures fast updates, reducing the need for frequent confirmations.
- **Efficient Gossip Protocol**: Lightweight synchronization keeps network traffic minimal while maintaining real-time accuracy.
- **Fault Tolerance**: Built-in redundancy ensures seamless gameplay even in the face of player dropouts.
- **Scalable Architecture**: Dynamic shard splitting and merging adapt to changing player counts, optimizing resource allocation.

---

## **Anarchy Consensus Protocol Roadmap**

| **Version** | **Milestone**                                    | **Key Features**                                                                                 |
|-------------|--------------------------------------------------|--------------------------------------------------------------------------------------------------|
| **v0.1.0**  | Core Networking                                  | P2P networking layer, shard and Czar management.                                                |
| **v0.2.0**  | State Synchronization                            | Gossip protocol, conflict resolution, cryptographic validation.                                 |
| **v0.3.0**  | Fault Tolerance and Debugging                    | Heartbeat monitoring, adaptive rate control, debugging tools for shard states and latency.       |
| **v0.4.0**  | Scalability                                      | Dynamic shard splitting/merging, delta updates for shard data, large-scale peer tests.           |

---

## **How It Works**

### **Data Sharding and Czar Management**
The game state is divided into logical shards, with each shard representing specific data (e.g., player stats, objects, events). While every player has a complete copy of the state, only the assigned **Czar** has authority to update specific shards.

- **Czars**: Each shard is managed by one Czar, responsible for updates and maintaining shard integrity.
- **Backup Czars**: Pre-assigned backups ensure seamless transitions when a Czar disconnects.

---

### **Consensus Mechanism**
The protocol resolves data conflicts using a lightweight consensus model:
- **Majority Vote**: Critical updates require agreement from a majority of peers to ensure consistency.
- **Versioning**: Each update includes a version number to prevent conflicts caused by outdated state changes.

---

### **Peer-to-Peer Communication**
The protocol operates in a serverless, peer-to-peer environment:
- **UDP-Based Communication**: UDP ensures fast, low-latency messaging for real-time updates.
- **Optimistic Replication**: Changes are applied locally by Czars and broadcast to peers, minimizing update lag.

---

### **Reallocation Protocol**
When a Czar leaves:
- **Heartbeat Monitoring**: Czars periodically send status updates. If a heartbeat is missed, a Backup Czar automatically takes over.
- **Seamless Reallocation**: Backup Czars assume responsibilities without interrupting gameplay.

---

### **Delta Updates**
- **Change Efficiency**: Only deltas (state changes) are transmitted, reducing network bandwidth usage.
- **Compression**: Optimized data transfer ensures low-latency state synchronization, even under heavy load.

---

### **Adaptive Rate Control**
- **Dynamic Update Frequency**: The system adjusts the frequency of state updates based on network conditions.
- **Prioritization**: Critical updates are prioritized to maintain gameplay integrity.

---

### **Shard Splitting and Merging**
- **Dynamic Scaling**: As player counts change, shards are split or merged to optimize load distribution.
- **Balanced Management**: Ensures no shard becomes overloaded or neglected.

---

### **Debugging and Monitoring Tools**
- **State Monitoring**: Tools to visualize shard assignments, network activity, and peer health.
- **Latency Tracking**: Real-time feedback on network performance, bandwidth usage, and peer connections.

---

### **State Validation**
To ensure data integrity, all state changes are verified:
- **Digital Signatures**: Updates are signed by Czars to prevent tampering.
- **Checksum Verification**: Players validate state changes against checksums of previous states.

---

## **License**

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
