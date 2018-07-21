export interface IGetChit {
    id: number;
    name: string;
    value: number;
    noOfMonths: number;
    noOfUsers: number;
    createDate: string;
    startDate: string;
    endDate: string;
    statusId: number;
    statusText: string;
    managerId: number;
    auctionDate: string;
    chitUsers: any[];
}
