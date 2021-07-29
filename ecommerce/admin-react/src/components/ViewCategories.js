import React, { Component } from 'react';
import service from "../modules/service";

export class ViewCategories extends Component {

    constructor(props) {
        super(props);
        this.state = { categories: [] }
    }

    refreshList() {
        fetch('https://localhost:44320/api/home/get-categories')
        .then(response=>response.json())
        .then(data=>{
            this.setState({categories:data});
        });
    }

    componentDidMount() {
        this.refreshList();
    }

    componentDidUpdate() {
        this.refreshList();
    }


    render() {
        const { categories } = this.state;
        return (
            <div >
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>CategoryId</th>
                            <th>CategoryName</th>
                            <th>Options</th>
                        </tr>
                    </thead>
                    <tbody>
                        {categories.map(c =>
                            <tr key={c.Id}>
                                <td>{c.Name}</td>
                                <td>{c.Description}</td>
                                <td>
                                    

                                </td>

                            </tr>)}
                    </tbody>

                </Table>

                <ButtonToolbar>
                    <Button variant='primary'
                        onClick={() => this.setState({ addModalShow: true })}>
                        Add Department</Button>

                    <AddDepModal show={this.state.addModalShow}
                        onHide={addModalClose} />
                </ButtonToolbar>
            </div>
        )
    }
}