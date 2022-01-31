import React from 'react';
import { render, screen } from '@testing-library/react';
import { act } from "react-dom/test-utils";
import ReactDOM, { unmountComponentAtNode } from "react-dom";
import ReactTestUtils from 'react-dom/test-utils'; // ES6
//var ReactTestUtils = require('react-dom/test-utils'); // ES5 with npm

import NewProject from './NewProject';

let container: HTMLDivElement;
beforeEach(() => {
    container = document.createElement("div");
    document.body.appendChild(container);
});

afterEach(() => {
    unmountComponentAtNode(container);
    container.remove();
});

test('Should send proper request to API', () => {

    const mockSuccessResponse = {  };
    const mockJsonPromise = Promise.resolve(mockSuccessResponse);
    const mockFetchPromise = Promise.resolve({
        json: () => mockJsonPromise,
    });
    const fakeFetch = jest.fn().mockImplementation(() => mockFetchPromise);
    window.fetch = fakeFetch;

    act(() => {
        ReactDOM.render(<NewProject />, container);
    });

    const name = document.querySelector<HTMLInputElement>("input[name='name']");
    const desc = document.querySelector<HTMLTextAreaElement>("textarea[name='description']");
    const button = document.querySelector<HTMLInputElement>("input[type='submit']");

    act(() => {
        if (name !== null) {
            name.value = "ut name";
            ReactTestUtils.Simulate.change(name);
        }
        if (desc !== null) {
            desc.value = "ut desc";
            ReactTestUtils.Simulate.change(desc);
        }
    });

    act(() => {
        if (button !== null) {
            button.dispatchEvent(new MouseEvent("click", { bubbles: true }));
        }
    });

    console.log(JSON.stringify(fakeFetch.mock.calls[0][1]));

    expect(fakeFetch.mock.calls[0][1].method).toBe("POST");
    expect(fakeFetch.mock.calls[0][1].headers["Content-type"]).toBe("application/json");
    let body = JSON.parse(fakeFetch.mock.calls[0][1].body);
    expect(body.Name).toBe("ut name");
    expect(body.Description).toBe("ut desc");

    (window.fetch as jest.Mock<any,any>).mockRestore();
});
