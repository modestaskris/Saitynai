export interface ISong {
    id: number,
    url: string
    title: string
    downladed: boolean;
}

export const Song: ISong = {
    downladed: false,
    id: -1,
    title: '',
    url: ''
}
