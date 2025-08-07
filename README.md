# Simple Server-Sent Events (SSE) Example with .NET 9

A concise demo showcasing Server-Sent Events using .NET 9's minimal API approach.

## Highlights

- **Compact Codebase**: Only 24 lines of C# for the server
- **Live Streaming**: Sends updates every second
- **Automatic Reconnection**: Browser handles reconnects on connection loss
- **No External Libraries**: Built entirely with .NET 9's native features

## Project Layout

```
SSE-Demo/
├── Program.cs          # Minimal API server code
├── wwwroot/
│   └── index.html     # Client-side interface (45 lines)
└── SSE-Demo.csproj  # .NET project configuration
```

## How It Operates

1. **Server-Side** (`Program.cs`):
   - Sets up a minimal web API with `WebApplication.Create()`
   - Serves static content from the `wwwroot` folder
   - Provides an `/sse` endpoint for streaming updates every second
   - Configures SSE headers (`text/event-stream`, `no-cache`)

2. **Client-Side** (`index.html`):
   - Connects to the `/sse` endpoint using the `EventSource` API
   - Displays messages as they arrive in real time
   - Shows connection state (Connected/Disconnected)
   - Automatically reconnects if the connection drops

## Running the Example

```bash
# Compile and launch
dotnet run

# Visit in browser
http://localhost:5000
```

## Core SSE Features Shown

- **Event Stream Structure**: Messages use the `data: <content>\n\n` format
- **Persistent Connection**: Server keeps sending updates until the client disconnects
- **Reconnection Handling**: `EventSource` in the browser auto-reconnects on errors
- **Push Updates**: Server delivers data instantly without client polling

## Prerequisites

- .NET 9 SDK
- Modern web browser (Chrome, Firefox, Edge, etc.)

## Why Use SSE?

Server-Sent Events are ideal for:
- Real-time alerts and notifications
- Live data streams (e.g., stock prices, news feeds)
- Progress tracking for long-running tasks
- One-directional server-to-client communication

SSE offers a simpler alternative to WebSockets for scenarios where only server-to-client updates are needed.
