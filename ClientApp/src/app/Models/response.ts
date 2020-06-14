export class Response<T> {
  Model: T;
  IsSuccess: boolean;
  Message: string;
  MessageType: number;
  Errors: string[]
}
