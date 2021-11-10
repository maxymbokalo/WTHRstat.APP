export class Emission {
    [x: string]: any;
    constructor(
        public id?: number,
        public source_Id?: number,
        public concentration?: number,
        public units?: string,
        public pollutant?: string,
        public date?: Date) { }
}
