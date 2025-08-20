export type ChatMessage = { role: 'user' | 'ai'; text: string };

export interface UserMessage {
    id: number;
    userId: number;
    message: string;
}

export interface UserMessageCreateDTO {
    userId: number,
    message: string,
}

export interface ChelloMessage {
    id: number;
    userId: number;
    message: string;
}
