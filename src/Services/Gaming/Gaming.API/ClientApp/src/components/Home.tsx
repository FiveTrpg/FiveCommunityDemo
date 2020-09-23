import * as React from 'react';
import { connect } from 'react-redux';
import { Button, Jumbotron } from 'reactstrap';
import { ApplicationPaths, QueryParameterNames } from './api-authorization/ApiAuthorizationConstants';
import authService from './api-authorization/AuthorizeService';

interface HomeState {
  user: any,
};

class Home extends React.Component<{}, HomeState> {
  /**
   *
   */
  constructor(props: {}) {
    super(props);
    this.state = { user: null };
  }
  componentDidMount() {
    this.loadUser();
  }

  async loadUser() {
    const user = await authService.getUser();
    this.setState({ user });
  }

  onRegisterClick = () => {
    var link = document.createElement("a");
    link.href = "/";
    const returnUrl = `${link.protocol}//${link.host}${link.pathname}${link.search}${link.hash}`;
    const redirectUrl = `${ApplicationPaths.Login}?${QueryParameterNames.ReturnUrl}=${encodeURI(returnUrl)}`
    window.location.href = redirectUrl;
  }

  render() {
    const { user } = this.state;
    return (
      <Jumbotron>
        <h1 className="display-3">欢迎, </h1>
        <p className="lead">{user ? user.name : ''}</p>
        <hr className="my-2" />
        { !user && (
          <div>
            <p>三次元废物聚集地，限时开放注册</p>
            <p className="lead">
              <Button color="primary" onClick={this.onRegisterClick}>立即注册</Button>
            </p>
          </div>
        )}
      </Jumbotron>
    );
  }
}

export default connect()(Home);
