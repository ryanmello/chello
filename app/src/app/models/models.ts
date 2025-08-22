export interface User {
    id: number;
    firstName: string;
    lastName: string;
    threads: Thread[];
}

export interface Thread {
    id: number;
    userId: number;
    user: User;
    title: string;
    messages: Message[];
    createdAt: Date;
}

export interface UIMessage {
    isHumanMessage: boolean;
    content: string;
}

export interface Message {
    id: number;
    threadId: number;
    thread: Thread;
    userId: number;
    user: User;
    content: string;
    isHumanMessage: boolean;
    createdAt: Date;
}

export interface MessageCreateDTO {
    userId: number;
    threadId?: number;
    content: string;
}
