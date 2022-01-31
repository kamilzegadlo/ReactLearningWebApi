import React from 'react';

type NewProjectState = {
    Name: string,
    Description: string
}

class NewProject extends React.Component<any, NewProjectState> {
    constructor(props: any) {
        super(props);
        this.state = { Name: '', Description: '' };

        this.handleNameChange = this.handleNameChange.bind(this);
        this.handleDescChange = this.handleDescChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleNameChange(event: any) {
        this.setState({ Name: event.target.value });
    }

    handleDescChange(event: any) {
        this.setState({ Description: event.target.value });
    }

    handleSubmit(event: any) {
        event.preventDefault();

        let projectInfo = {
            Name: this.state.Name,
            Description: this.state.Description
        }

        fetch('https://localhost:7023/api/project', {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(projectInfo),
        }).then(r => r.json()).then(res => {
            if (res) {
            }
        });
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <p>
                    Adding a new project:
                </p>
                <label>
                    Name:
                    <input type="text" name="name" value={this.state.Name} onChange={this.handleNameChange} />
                </label><br />
                <label>
                    Description:
                    <textarea name="description" value={this.state.Description} onChange={this.handleDescChange} />
                </label><br />
                <input type="submit" value="Submit" />
            </form>
        );
    }
}

export default NewProject;







