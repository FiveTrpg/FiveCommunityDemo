import * as React from 'react';
import { connect } from 'react-redux';
import { Button, Col, Container, Jumbotron, Row } from 'reactstrap';
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
    if (!user) {
      return (<h1>服务器错误</h1>);
    }
    return (
      <Container>
        <Row>
          <Col>今天是废物社区 元年一月一日</Col>
        </Row>
      </Container>
    );
  }
}

export default connect()(Home);
